using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace NHL_Draft_Lottery_Simulator
{
    public partial class Form1 : Form
    {
        public static Random _rand = new Random();
        private List<LotteryTeam> LottoTeams = new List<LotteryTeam>();
        private BindingSource BSource = new BindingSource();
        private int BallsDrawn = 0;

        // Number of lottery combinations for each lottery position
        private List<int> LotteryEntries =
            new List<int>() { 185, 135, 115, 95, 85, 75, 65, 60, 50, 35, 30, 25, 20, 15, 10 };

        // Dictionary to hold all entry number and the four ball combination
        private Dictionary<int, List<int>> Ticket = new Dictionary<int, List<int>>();
        private Dictionary<int, string> TeamWithTicketNumber = new Dictionary<int, string>();

        // Dictionary of the winning combination Key: 1st/2nd/3rd Overall, Value - Winning combination
        private Dictionary<int, List<int>> WinningCombo = new Dictionary<int, List<int>>();

        // List of possible winners for current draw
        private List<int> PossibleWinners = new List<int>();

        // Number of lottery balls
        private const int MAXBALLS = 14;

        public Form1()
        {
            InitializeComponent();
        }
        
        // Import Standings From File in order of lowest points (highest odds to win draft)
        private void UI_BTN_LoadStandings_Click(object sender, EventArgs e)
        {
            if (UI_OFD_Import.ShowDialog() == DialogResult.OK)
            {
                UI_BTN_LoadStandings.Enabled = false;

                // Import info
                try
                {
                    List<string> Import = new List<string>(File.ReadAllLines(UI_OFD_Import.FileName));
                    int count = 0;
                    foreach(string line in Import)
                    {
                        LottoTeams.Add(new LotteryTeam(line.Split(new char[] { '\t'}).First().Trim(), ++count, LotteryEntries[count - 1]));
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Could not read file: " + error);
                    UI_BTN_LoadStandings.Enabled = true;
                    return;
                }

                UI_BTN_Draw.Enabled = true;
                UI_BTN_GenerateCombos.Enabled = true;
                UI_BTN_Reset.Enabled = true;
                UI_BTN_Result.Enabled = true;

                // Sort teams by name and update combo box to display each team
               //*********** UI_CB_SelectTeam.Items.Add("Default");
                LottoTeams = LottoTeams.OrderBy(o => o.TeamName).ToList();
                LottoTeams.ForEach(o => UI_CB_SelectTeam.Items.Add(o.TeamName));
                RandomizeEntries();

                // Display initial odds and link binding source to data grid view
                ShowDefaultOdds();
                UI_DGV.DataSource = BSource;
            }
        }

        private void UI_BTN_GenerateCombos_Click(object sender, EventArgs e)
        {
            if (LottoTeams.Count < 1)
                return;

            Reset();
            RandomizeEntries();
        }

        // Randomly assign entries to each team
        private void RandomizeEntries()
        {
            int index = 0;

            // Reset variables
            WinningCombo.Clear();
            BallsDrawn = 0;
            Ticket.Clear();
            TeamWithTicketNumber.Clear();
            LottoTeams.ForEach(o => o.Entries.Clear());

            // Create combos
            for (int ball1 = 1; ball1 <= 10; ++ball1)
                for (int ball2 = ball1 + 1; ball2 <= 12; ++ball2)
                    for (int ball3 = ball2 + 1; ball3 <= 13; ++ball3)
                        for (int ball4 = ball3 + 1; ball4 <= 14; ++ball4)
                        {
                            List<int> entry = new List<int>() { ball1, ball2, ball3, ball4 };
                            Ticket.Add(++index, entry);
                        }

            // Remove the unassigned entry (11, 12, 13, 14) - a redraw would be required
            Ticket.Remove(1001);

            // Randomize entries 
            List<int> EntryNum = new List<int>(Ticket.Keys.OrderBy(o => _rand.Next()));
            index = 0;
            
            // Assign each team the alloted amount of random tickets
            foreach (LotteryTeam team in LottoTeams)
            {
                int TeamEntries = 0;

                while (TeamEntries < team.NumCombos)
                {
                    team.Entries.Add(EntryNum[index]);
                    TeamWithTicketNumber.Add(EntryNum[index++], team.TeamName);
                    ++TeamEntries;
                }
            }

            ShowDefaultOdds();
        }

        // Drop down box - team selected change event handler
        private void UI_CB_SelectTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int place = WinningCombo.Keys.Count;
            int ballCount = place > 0 ? WinningCombo[place].Count : 0;

            LotteryTeam Selected = LottoTeams.First(o => o.TeamName == (string)UI_CB_SelectTeam.SelectedItem);

            // No balls draw, show all combinations
            if (BallsDrawn == 0)
            {
                BSource.DataSource = from num in Selected.Entries
                                     orderby num
                                     select new
                                     {
                                         Entry = num,
                                         Combination = Ticket[num][0] + " "
                                                     + Ticket[num][1] + " "
                                                     + Ticket[num][2] + " "
                                                     + Ticket[num][3]
                                     };
            }
            else
            {
                // Show all tickets that can still win by team selected in combo box
                Dictionary<int, List<int>> PotentialMatches = new Dictionary<int, List<int>>();
                
                List<int> Matches = new List<int>();
                foreach(int index in Selected.Entries)
                {
                    if (Ticket[index].Intersect(WinningCombo[place]).ToList().Count.Equals(ballCount))
                        Matches.Add(index);
                }

                BSource.DataSource = from num in Matches
                                     orderby num
                                     select new
                                     {
                                         EntryNumber = num,
                                         Combination = Ticket[num][0] + " "
                                                     + Ticket[num][1] + " "
                                                     + Ticket[num][2] + " "
                                                     + Ticket[num][3]
                                     };
            }
        }

        // Event handler for drawing a lottery ball
        private void UI_BTN_Draw_Click(object sender, EventArgs e)
        {
            if (LottoTeams.Count < 1)
                return;

            UI_LBL_Info.Text = "";
            UI_CB_SelectTeam.ResetText();
            ++BallsDrawn;

            if (BallsDrawn >= 12)
            {
                UI_BTN_Draw.Enabled = false;
                UI_BTN_Result.Enabled = false;
            }
            switch (BallsDrawn)
            {
                case 1:     // First Ball Drawn for 1st Overall
                case 5:     // First Ball Drawn for 2nd Overall
                case 9:     // First Ball Drawn for 3rd Overall
                    PossibleWinners.Clear();
                    PossibleWinners = Ticket.Keys.ToList();
                    int ball1 = _rand.Next(1, MAXBALLS + 1);
                    WinningCombo.Add(BallsDrawn / 4 + 1, new List<int>() { ball1 });
                    PossibleWinners.RemoveAll(o => !Ticket[o].Contains(ball1));
                    break;
                default:
                    // Get a new unique ball
                    int NewBall = DrawNewBall(WinningCombo[(BallsDrawn - 1) / 4 + 1]);
                    WinningCombo[(BallsDrawn - 1)/ 4 + 1].Add(NewBall);
                    PossibleWinners.RemoveAll(o => !Ticket[o].Contains(NewBall));
                    break;
            }

            // Update Textboxes
            if (BallsDrawn <= 4)
                UpdateLotteryTextBox(1, WinningCombo[1]);
            else if (BallsDrawn <= 8)
                UpdateLotteryTextBox(2, WinningCombo[2]);
            else
                UpdateLotteryTextBox(3, WinningCombo[3]);

            UpdateDataGridView();
        }

        // Recursive function until a new unique ball from 1 to 14 is drawn 
        private int DrawNewBall (List<int> WinningNumbers)
        {
            int ball = _rand.Next(1, MAXBALLS + 1);
            return WinningNumbers.Contains(ball) ? DrawNewBall(WinningNumbers) : ball;
        }

        // Update the text/picture boxes after drawing a ball
        private void UpdateLotteryTextBox(int place, List<int> Numbers)
        {
            if (place < 1 || place > 3)
                throw new ArgumentException("You may only draw for the first three positions");

            string output = "";
            WinningCombo[place].ForEach(o => output += o + " ");

            string winner = "";
            Image winnerPic = null;

            if (Numbers.Count == 4)
            {
                // Search entire list of winning combos until we find the team with the winning numbers
                List<int> WinningNumber = new List<int>(Numbers);
                WinningNumber.Sort();

                if (WinningNumber[0] == 11)
                {
                    UI_LBL_DGV_Title.Text = "Winning Combo 11, 12, 13, 14! Redraw!";
                    Redraw(place);
                }
                
                foreach (LotteryTeam team in LottoTeams)
                {
                    if (team.Entries.Contains(PossibleWinners[0]))
                    {
                        winner = team.TeamName;
                        winnerPic = team.Logo;
                    }
                }

                string result = string.Format("The combination: {0} {1} {2} {3} belongs to " + winner + ". Redraw required",
                                                WinningNumber[0], WinningNumber[1], WinningNumber[2], WinningNumber[3]);
                

                // Check if winning team has already won 1st or 2nd overall
                if (place.Equals(2) && winner.Equals(UI_TB_1Winner.Text))
                {
                    Redraw(2);
                    UI_LBL_Info.Text = result;
                    return;
                }
                else if (winner.Equals(UI_TB_1Winner.Text) || winner.Equals(UI_TB_2Winner.Text))
                {
                    Redraw(3);
                    UI_LBL_Info.Text = result;
                    return;
                }
            }
         
            switch (place)
            {
                case 1:
                    UI_TB_1Overall.Text = output;
                    if (Numbers.Count == 4)
                    {
                        UI_TB_1Winner.Text = winner;
                        UI_PB1.Image = winnerPic;
                    }
                    break;
                case 2:
                    UI_TB_2Overall.Text = output;
                    if (Numbers.Count == 4)
                    {
                        UI_TB_2Winner.Text = winner;
                        UI_PB2.Image = winnerPic;
                    }
                    break;
                case 3:
                    UI_TB_3Overall.Text = output;
                    if (Numbers.Count == 4)
                    {
                        UI_TB_3Winner.Text = winner;
                        UI_PB3.Image = winnerPic;
                    }
                    break;
            }
        }

        // A repeat winner occur, update the UI
        private void Redraw(int place)
        {
            WinningCombo.Remove(place);
            
            BallsDrawn -= 4;
            PossibleWinners = Ticket.Keys.ToList();

            switch (place)
            {
                case 2:
                    UI_TB_2Overall.Text = "";
                    break;
                case 3:
                    UI_TB_3Overall.Text = "";
                    UI_BTN_Draw.Enabled = true;
                    UI_BTN_Result.Enabled = true;
                    break;
            }
        }

        private void UpdateDataGridView()
        {
            // Ball 1 or 2 for current draw
            if ((BallsDrawn - 1) % 4 == 0 || (BallsDrawn - 1) % 4 == 1)
                UpdateDGV_TeamOdds();
            else if ((BallsDrawn - 1) % 4 == 2) // Ball 3 for current draw
                UpdateDGV_LastDraw(WinningCombo.Keys.Count);
            else if (BallsDrawn == 4)
            {
                LotteryTeam Winner = GetWinner(1);
                UpdateDGV_WinningEntry(Winner, 1);
            }
            else if (BallsDrawn == 8)
            {
                LotteryTeam Winner = GetWinner(2);
                UpdateDGV_WinningEntry(Winner, 2);
            }
            else if (BallsDrawn == 12)          // All 12 balls drawn
                UpdateDGV_FinalDraftOrder();
        }

        private LotteryTeam GetWinner(int place)
        {
            // Find the team with the current winning selection
            string WinningNumbers = "";
            string WinningTeam = "";
            LotteryTeam Winner = null;

            WinningCombo[place].ForEach(o => WinningNumbers += o + " ");
            WinningCombo[place].Sort();

            foreach (KeyValuePair<int, List<int>> kvp in Ticket)
            {
                if (kvp.Value.SequenceEqual(WinningCombo[place]))
                {
                    WinningTeam = TeamWithTicketNumber[kvp.Key];
                    LottoTeams.ForEach(o => { if (o.TeamName.Equals(WinningTeam)) Winner = o; });
                }
            }

            return Winner;
        }
        // Show Odds before any balls drawn
        private void ShowDefaultOdds()
        {
            BSource.DataSource = from t in LottoTeams
                                 orderby t.LotteryPlacement
                                 select new
                                 {
                                     Team = t.TeamName,
                                     Odds = string.Format("{0, 6:f2} %", t.Entries.Count / (double)1000 * 100)
                                 };
        }

        // After Ball 1 or 2 is drawn 
        private void UpdateDGV_TeamOdds()
        {
             BSource.DataSource = from team in LottoTeams
                                  orderby team.Entries.Intersect(PossibleWinners).ToList().Count descending
                                  select new
                                  {
                                      Team = team.TeamName,
                                      Entries = team.Entries.Intersect(PossibleWinners).ToList().Count,
                                      Odds = string.Format("{0:f2} %", team.Entries.Intersect(PossibleWinners).ToList().Count 
                                                                      / (double)PossibleWinners.Count* 100)
                                  };
        }

        // After Ball 3 is drawn - displays each team and which ball(s) they require to win
        private void UpdateDGV_LastDraw(int place)
        {
            Dictionary<string, List<int>> outcome = new Dictionary<string, List<int>>();

            foreach (int num in PossibleWinners)
            {
                if (!outcome.ContainsKey(TeamWithTicketNumber[num]))
                    outcome.Add(TeamWithTicketNumber[num], new List<int>() { Ticket[num].Except(WinningCombo[place]).ToList().First()});
                else
                    outcome[TeamWithTicketNumber[num]].Add(Ticket[num].Except(WinningCombo[place]).ToList().First());
            }

            Dictionary<string, string> display = LottoTeams.ToDictionary(o => o.TeamName, o => "");
            foreach (KeyValuePair<string, List<int>> kvp in outcome)
            {
                string output = "";
                kvp.Value.Sort();
                kvp.Value.ForEach(o => output += o + " ");
                display[kvp.Key] = output;
            }
      
            BSource.DataSource = from team in LottoTeams
                                 orderby team.Entries.Intersect(PossibleWinners).ToList().Count descending
                                 select new
                                 {
                                     Team = team.TeamName,
                                     Entries = team.Entries.Intersect(PossibleWinners).ToList().Count,
                                     WinningNumbers = display[team.TeamName],
                                     Odds = string.Format("{0:f2} %", team.Entries.Intersect(PossibleWinners).ToList().Count
                                                                     / (double)PossibleWinners.Count * 100)
                                 };

        }

        //  Display exact order of the draft after the completion of the lottery
        private void UpdateDGV_FinalDraftOrder()
        {
            Dictionary<int, string> DraftOrder = 
                new Dictionary<int, string>
                    { { 1, UI_TB_1Winner.Text },
                      { 2, UI_TB_2Winner.Text },
                      { 3, UI_TB_3Winner.Text } };

            LottoTeams = LottoTeams.OrderBy(o => o.LotteryPlacement).ToList();
            LottoTeams.ForEach(o => { if (!DraftOrder.ContainsValue(o.TeamName)) DraftOrder.Add(DraftOrder.Count + 1, o.TeamName); });

            BSource.DataSource = from team in DraftOrder
                                 select team;
            UI_DGV.Columns[0].HeaderText = "Draft Order";
            UI_DGV.Columns[1].HeaderText = "Team";           
        }

        private void UI_BTN_Reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            BallsDrawn = 0;
            WinningCombo.Clear();
            UI_TB_1Overall.Text = UI_TB_1Winner.Text = "";
            UI_TB_2Overall.Text = UI_TB_2Winner.Text = "";
            UI_TB_3Overall.Text = UI_TB_3Winner.Text = "";
            UI_PB1.Image = null;
            UI_PB2.Image = null;
            UI_PB3.Image = null;
            UI_BTN_Draw.Enabled = true;
            UI_BTN_Result.Enabled = true;
            ShowDefaultOdds();
        }

        private LotteryTeam GetWinnerImmediately()
        {
            int PlaceToDrawFor = BallsDrawn / 4 + 1;

            // No balls drawn yet for current draft position 1, 2, or 3 - create new list to hold winning numbers
            if (BallsDrawn == 0 || BallsDrawn == 4 || BallsDrawn == 8)
            {
                if (!WinningCombo.ContainsKey(PlaceToDrawFor))
                    WinningCombo.Add(PlaceToDrawFor, new List<int>());
            }

            // Keep drawing balls until you find a possible winner
            do  
            {
                WinningCombo[PlaceToDrawFor].Add(DrawNewBall(WinningCombo[PlaceToDrawFor]));
                ++BallsDrawn;
            } while (WinningCombo[PlaceToDrawFor].Count < 4);

            LotteryTeam Winner = GetWinner(PlaceToDrawFor);
            string WinningTeam = Winner.TeamName;
            string WinningNumbers = "";
            
            WinningCombo[PlaceToDrawFor].ForEach(o => WinningNumbers += o + " ");
            WinningCombo[PlaceToDrawFor].Sort();

            // Check if the team has already won 
            if (WinningTeam == UI_TB_1Winner.Text || WinningTeam == UI_TB_2Winner.Text)
            {
                BallsDrawn -= 4;
                WinningCombo[PlaceToDrawFor].Clear();
                Winner = GetWinnerImmediately();
            }

            // Display the winner combo
            switch(PlaceToDrawFor)
            {
                case 1:
                    UI_TB_1Overall.Text = WinningNumbers;
                    break;
                case 2:
                    UI_TB_2Overall.Text = WinningNumbers;
                    break;
                case 3:
                    UI_TB_3Overall.Text = WinningNumbers;
                    break;
            }

            return Winner;
        }
        // Event handler to get an immediate winner for the current drawing (1st/2nd/3rd overall)
        private void UI_BTN_Result_Click(object sender, EventArgs e)
        {
            LotteryTeam Winner = GetWinnerImmediately();

            switch (BallsDrawn / 4)
            {
                case 1:
                    UI_TB_1Winner.Text = Winner.TeamName;
                    UI_PB1.Image = Winner.Logo;
                    UpdateDGV_WinningEntry(Winner, 1);
                    break;
                case 2:
                    UI_TB_2Winner.Text = Winner.TeamName;
                    UI_PB2.Image = Winner.Logo;
                    UpdateDGV_WinningEntry(Winner, 2);
                    break;
                case 3:
                    UI_TB_3Winner.Text = Winner.TeamName;
                    UI_PB3.Image = Winner.Logo;
                    UI_BTN_Draw.Enabled = false;
                    UI_BTN_Result.Enabled = false;
                    UpdateDGV_FinalDraftOrder();
                    break;
            }
        }

        private LotteryTeam FindWinner()
        {
            return null;
        }
        // Update the DGV after a winner is drawn for 1st or 2nd overall
        private void UpdateDGV_WinningEntry(LotteryTeam Selected, int place)
        {
            // Show all tickets that can still win by team selected in combo box
            Dictionary<int, List<int>> PotentialMatches = new Dictionary<int, List<int>>();

            List<int> Matches = new List<int>();
            foreach (int index in Selected.Entries)
            {
                if (Ticket[index].Intersect(WinningCombo[place]).ToList().Count.Equals(4))
                    Matches.Add(index);
            }

            BSource.DataSource = from num in Matches
                                 orderby num
                                 select new
                                 {
                                     EntryNumber = num,
                                     Combination = Ticket[num][0] + " "
                                                 + Ticket[num][1] + " "
                                                 + Ticket[num][2] + " "
                                                 + Ticket[num][3]
                                 };
        }
    }    
}
