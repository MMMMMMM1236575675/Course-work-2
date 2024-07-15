namespace WinFormsApp164
{
    public partial class Form1 : Form
    {
        List<Vidrizok> list;
        public Form1()
        {
            InitializeComponent();
            list = new List<Vidrizok>();
        }
        string nameFile = @"C:\«адача√рупи¬≥др≥зк≥в“очкиѕеретин\vidrizok.txt";
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFromFile(nameFile);
            for(int i = 0; i < list.Count; i++)
                for(int j = i; j < list.Count; j++)
                    Vidrizok.IsPeretun(list[i], list[j]);
            Vidrizok.FindFuckingGroupe(list);
            Console.WriteLine("Hello");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Vidrizok v in list)
                e.Graphics.DrawLine(new Pen(Color.Black,2), v.p1,v.p2);
            foreach (Vidrizok v in list.Where((x) => x.NumberOfGroupe == 1))
                e.Graphics.DrawLine(new Pen(Color.Green, 3), v.p1, v.p2);
            foreach (Vidrizok v in list.Where((x)=>x.NumberOfGroupe==2))
                e.Graphics.DrawLine(new Pen(Color.Red,3), v.p1, v.p2);
            foreach (Vidrizok v in list.Where((x) => x.NumberOfGroupe == 3))
                e.Graphics.DrawLine(new Pen(Color.Violet, 3), v.p1, v.p2);
            foreach (Vidrizok v in list.Where((x) => x.NumberOfGroupe == 4))
                e.Graphics.DrawLine(new Pen(Color.Blue, 3), v.p1, v.p2);

        }
        void ReadFromFile(string nameFile)
        {
            StreamReader sr = new StreamReader(nameFile);
            string str = "";
            string[] arrStr;
            while (true)
            {
                str = sr.ReadLine();
                if (str == null)
                    break;
                arrStr = str.Split(',', ' ', ';');
                list.Add(new Vidrizok(new Point(int.Parse(arrStr[4]),int.Parse(arrStr[8])),new Point(int.Parse(arrStr[12]),int.Parse(arrStr[16]))));
            }
        }
    }
}
