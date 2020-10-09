using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Algoritmo_de_Dijkstra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Araguari = new Node("Araguari");
            var Ind = new Node("Indianópolis");
            var Monte = new Node("Monte Alegre de Minas");
            var Prata = new Node("Prata");
            var Tupa = new Node("Tupaciguara");
            var Ura = new Node("Uberaba");
            var Udi = new Node("Uberlândia");
            var Vero = new Node("Veríssimo");
            var Com = new Node("Comendador Gomes");

            Path[] paths = new Path[34];
            paths[0] = new Path(Araguari, Ind, 62);
            paths[1] = new Path(Ind, Araguari, 62);
            paths[2] = new Path(Araguari, Tupa, 70);
            paths[3] = new Path(Tupa, Araguari, 70);
            paths[4] = new Path(Araguari, Udi, 39);
            paths[5] = new Path(Udi, Araguari, 39);
            paths[6] = new Path(Araguari, Vero, 107);
            paths[7] = new Path(Vero, Araguari, 107);
            paths[8] = new Path(Ind, Udi, 50);
            paths[9] = new Path(Udi, Ind, 50);
            paths[10] = new Path(Monte, Prata, 74);
            paths[11] = new Path(Prata, Monte, 74);
            paths[12] = new Path(Monte, Tupa, 70);
            paths[13] = new Path(Tupa, Monte, 70);
            paths[14] = new Path(Monte, Udi, 69);
            paths[15] = new Path(Udi, Monte, 69);
            paths[16] = new Path(Prata, Ura, 146);
            paths[17] = new Path(Ura, Prata, 146);
            paths[18] = new Path(Prata, Udi, 86);
            paths[19] = new Path(Udi, Prata, 86);
            paths[20] = new Path(Tupa, Udi, 70);
            paths[21] = new Path(Udi, Tupa, 70);
            paths[22] = new Path(Ura, Udi, 107);
            paths[23] = new Path(Udi, Ura, 107);
            paths[24] = new Path(Udi, Vero, 140);
            paths[25] = new Path(Vero, Udi, 140);
            paths[26] = new Path(Prata, Vero, 128);
            paths[27] = new Path(Vero, Prata, 128);
            paths[28] = new Path(Ura, Vero, 47);
            paths[29] = new Path(Vero, Ura, 47);
            paths[30] = new Path(Com, Vero, 117);
            paths[31] = new Path(Vero, Com, 117);
            paths[32] = new Path(Prata, Com, 69);
            paths[33] = new Path(Com, Prata, 69);

            int opc1 = comboBox1.SelectedIndex;
            int opc2 = comboBox2.SelectedIndex;
            Node start = Araguari, end = Araguari;
            switch (opc1)
            {
                case 0:
                    start = Araguari;
                    break;
                case 1:
                    start = Com;
                    break;
                case 2:
                    start = Ind;
                    break;
                case 3:
                    start = Monte;
                    break;
                case 4:
                    start = Prata;
                    break;
                case 5:
                    start = Tupa;
                    break;
                case 6:
                    start = Ura;
                    break;
                case 7:
                    start = Udi;
                    break;
                case 8:
                    start = Vero;
                    break;
            }
            switch (opc2)
            {
                case 0:
                    end = Araguari;
                    break;
                case 1:
                    end = Com;
                    break;
                case 2:
                    end = Ind;
                    break;
                case 3:
                    end = Monte;
                    break;
                case 4:
                    end = Prata;
                    break;
                case 5:
                    end = Tupa;
                    break;
                case 6:
                    end = Ura;
                    break;
                case 7:
                    end = Udi;
                    break;
                case 8:
                    end = Vero;
                    break;
            }

            Node currentNode = start;
            currentNode.workingValue = 0;
            currentNode.orderOfLabelling = 1;

            Node[] nodes = new Node[] { Araguari, Ind, Monte, Prata, Tupa, Ura, Udi, Vero, Com };
            int labelCount = 2;
            int nodeCount = nodes.Count();
            bool loop = true;

            while (loop)
            {
                foreach (Path path in paths)
                {
                    if (path.nodeFrom == currentNode)
                    {
                        if (path.nodeTo.workingValue > (currentNode.workingValue + path.pathWeight))
                        {
                            path.nodeTo.workingValue = currentNode.workingValue + path.pathWeight;
                        }
                    }
                }
                int minWorkingValue = int.MaxValue;
                Node nextNode = currentNode;
                foreach (Node node in nodes)
                {
                    if (node.workingValue < minWorkingValue && node.orderOfLabelling == null)
                    {
                        minWorkingValue = node.workingValue;
                        nextNode = node;
                    }
                }
                currentNode = nextNode;
                nextNode.orderOfLabelling = labelCount;
                if (labelCount == nodeCount)
                {
                    loop = false;
                }
                labelCount++;
            }
            GetPath(nodes, paths, start, end);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int opc1 = comboBox1.SelectedIndex;
            int opc2 = comboBox2.SelectedIndex;

            label2.ForeColor = label5.ForeColor = label4.ForeColor = label9.ForeColor = label10.ForeColor = label7.ForeColor = label1.ForeColor = label3.ForeColor = label6.ForeColor = Color.Black;

            switch (opc1)
            {
                case 0:
                    label2.ForeColor = Color.Green;
                    break;
                case 1:
                    label6.ForeColor = Color.Green;
                    break;
                case 2:
                    label5.ForeColor = Color.Green;
                    break;
                case 3:
                    label4.ForeColor = Color.Green;
                    break;
                case 4:
                    label9.ForeColor = Color.Green;
                    break;
                case 5:
                    label10.ForeColor = Color.Green;
                    break;
                case 6:
                    label7.ForeColor = Color.Green;
                    break;
                case 7:
                    label1.ForeColor = Color.Green;
                    break;
                case 8:
                    label3.ForeColor = Color.Green;
                    break;

            }
            switch (opc2)
            {
                case 0:
                    label2.ForeColor = Color.Red;
                    break;
                case 1:
                    label6.ForeColor = Color.Red;
                    break;
                case 2:
                    label5.ForeColor = Color.Red;
                    break;
                case 3:
                    label4.ForeColor = Color.Red;
                    break;
                case 4:
                    label9.ForeColor = Color.Red;
                    break;
                case 5:
                    label10.ForeColor = Color.Red;
                    break;
                case 6:
                    label7.ForeColor = Color.Red;
                    break;
                case 7:
                    label1.ForeColor = Color.Red;
                    break;
                case 8:
                    label3.ForeColor = Color.Red;
                    break;
            }
            int itemSelected = comboBox1.SelectedIndex;
            if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
            {
                comboBox1.SelectedIndex = -1;
            }
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int opc1 = comboBox1.SelectedIndex;
            int opc2 = comboBox2.SelectedIndex;

            label2.ForeColor = label5.ForeColor = label4.ForeColor = label9.ForeColor = label10.ForeColor = label7.ForeColor = label1.ForeColor = label3.ForeColor = label6.ForeColor = Color.Black;

            switch (opc1)
            {
                case 0:
                    label2.ForeColor = Color.Green;
                    break;
                case 1:
                    label6.ForeColor = Color.Green;
                    break;
                case 2:
                    label5.ForeColor = Color.Green;
                    break;
                case 3:
                    label4.ForeColor = Color.Green;
                    break;
                case 4:
                    label9.ForeColor = Color.Green;
                    break;
                case 5:
                    label10.ForeColor = Color.Green;
                    break;
                case 6:
                    label7.ForeColor = Color.Green;
                    break;
                case 7:
                    label1.ForeColor = Color.Green;
                    break;
                case 8:
                    label3.ForeColor = Color.Green;
                    break;

            }
            switch (opc2)
            {
                case 0:
                    label2.ForeColor = Color.Red;
                    break;
                case 1:
                    label6.ForeColor = Color.Red;
                    break;
                case 2:
                    label5.ForeColor = Color.Red;
                    break;
                case 3:
                    label4.ForeColor = Color.Red;
                    break;
                case 4:
                    label9.ForeColor = Color.Red;
                    break;
                case 5:
                    label10.ForeColor = Color.Red;
                    break;
                case 6:
                    label7.ForeColor = Color.Red;
                    break;
                case 7:
                    label1.ForeColor = Color.Red;
                    break;
                case 8:
                    label3.ForeColor = Color.Red;
                    break;
            }

            if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
            {
                comboBox2.SelectedIndex = -1;
            }
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
        }

        private void GetPath(Node[] nodes, Path[] paths, Node start, Node end)
        {
            Node currentNode = end;
            bool loop = true;
            List<Node> finalPath = new List<Node>();
            finalPath.Add(currentNode);
            int totalWeight = 0;

            while (loop)
            {
                List<Node> relatedPaths = new List<Node>();
                bool found = false;
                int pathCount = 0;
                while (!found)
                {
                    Path currentPath = paths[pathCount];
                    if (currentPath.nodeTo == currentNode)
                    {
                        if (currentNode.workingValue - currentPath.pathWeight == currentPath.nodeFrom.workingValue)
                        {
                            finalPath.Add(currentPath.nodeFrom);
                            totalWeight += currentPath.pathWeight;
                            currentNode = currentPath.nodeFrom;
                            found = true;
                        }
                        else
                        {
                            pathCount++;
                        }
                    }
                    else
                    {
                        pathCount++;
                    }
                }
                if (currentNode == start)
                {
                    loop = false;
                }
            }
            finalPath.Reverse();
            string[] finalPathStrings = new string[finalPath.Count];
            for (int n = 0; n < finalPath.Count; n++)
            {
                finalPathStrings[n] = finalPath[n].name;


                if (label1.Text == finalPath[n].name && label1.ForeColor != Color.Green && label1.ForeColor != Color.Red)
                {
                    label1.ForeColor = Color.Blue;
                }
                if (label2.Text == finalPath[n].name && label2.ForeColor != Color.Green && label2.ForeColor != Color.Red)
                {
                    label2.ForeColor = Color.Blue;
                }
                if (label3.Text == finalPath[n].name && label3.ForeColor != Color.Green && label3.ForeColor != Color.Red)
                {
                    label3.ForeColor = Color.Blue;
                }
                if ("Monte Alegre de Minas" == finalPath[n].name && label4.ForeColor != Color.Green && label4.ForeColor != Color.Red)
                {
                    label4.ForeColor = Color.Blue;
                }
                if (label5.Text == finalPath[n].name && label5.ForeColor != Color.Green && label5.ForeColor != Color.Red)
                {
                    label5.ForeColor = Color.Blue;
                }
                if ("Comendador Gomes" == finalPath[n].name && label6.ForeColor != Color.Green && label6.ForeColor != Color.Red)
                {
                    label6.ForeColor = Color.Blue;
                }
                if (label7.Text == finalPath[n].name && label7.ForeColor != Color.Green && label7.ForeColor != Color.Red)
                {
                    label7.ForeColor = Color.Blue;
                }
                if (label9.Text == finalPath[n].name && label9.ForeColor != Color.Green && label9.ForeColor != Color.Red)
                {
                    label9.ForeColor = Color.Blue;
                }
                if (label10.Text == finalPath[n].name && label10.ForeColor != Color.Green && label10.ForeColor != Color.Red)
                {
                    label10.ForeColor = Color.Blue;
                }
            }
            label12.Text = "Rota mais rápida: \n" + string.Join(" -> ", finalPathStrings) + "\nCaminho: " + totalWeight.ToString() + "Km";
        }

        private void ShowLineJoin(PaintEventArgs e)
        {

            Pen pen = new Pen(System.Drawing.Color.Black, 3);
            pen.StartCap = LineCap.ArrowAnchor;
            pen.EndCap = LineCap.ArrowAnchor;
            //Udi - Monte
            e.Graphics.DrawLine(pen, 111, 167, 250, 167);
            e.Graphics.DrawString("69", new Font("Microsoft Sans Serif", 8), Brushes.Black, 179, 152);
            //Udi - Prata
            e.Graphics.DrawLine(pen, 141, 259, 270, 177);
            e.Graphics.DrawString("86", new Font("Microsoft Sans Serif", 8), Brushes.Black, 190, 203);
            //Udi - Vero
            e.Graphics.DrawLine(pen, 300, 330, 300, 175);
            e.Graphics.DrawString("140", new Font("Microsoft Sans Serif", 8), Brushes.Black, 303, 222);
            //Udi - Araguari
            e.Graphics.DrawLine(pen, 300, 40, 300, 149);
            e.Graphics.DrawString("39", new Font("Microsoft Sans Serif", 8), Brushes.Black, 303, 89);
            //Udi - Ind
            e.Graphics.DrawLine(pen, 340, 167, 460, 167);
            e.Graphics.DrawString("50", new Font("Microsoft Sans Serif", 8), Brushes.Black, 400, 152);
            //Udi - Tupa
            e.Graphics.DrawLine(pen, 150, 110, 260, 162);
            e.Graphics.DrawString("70", new Font("Microsoft Sans Serif", 8), Brushes.Black, 205, 121);
            //Udi - Ura
            e.Graphics.DrawLine(pen, 330, 180, 430, 252);
            e.Graphics.DrawString("107", new Font("Microsoft Sans Serif", 8), Brushes.Black, 395, 211);
            //Araguari - Tupa
            e.Graphics.DrawLine(pen, 289, 31, 170, 73);
            e.Graphics.DrawString("70", new Font("Microsoft Sans Serif", 8), Brushes.Black, 214, 37);
            //Monte - Tupa
            e.Graphics.DrawLine(pen, 50, 153, 100, 103);
            e.Graphics.DrawString("70", new Font("Microsoft Sans Serif", 8), Brushes.Black, 60, 113);
            //Monte - Prata
            e.Graphics.DrawLine(pen, 65, 200, 115, 250);
            e.Graphics.DrawString("74", new Font("Microsoft Sans Serif", 8), Brushes.Black, 95, 210);
            //Prata - Ura
            e.Graphics.DrawLine(pen, 151, 269, 400, 269);
            e.Graphics.DrawString("146", new Font("Microsoft Sans Serif", 8), Brushes.Black, 255, 254);
            //Araguari - vero
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddLine(new Point(355, 30), new Point(550, 30));
            path.AddLine(new Point(550, 335), new Point(365, 335));
            pen.LineJoin = LineJoin.Bevel;
            e.Graphics.DrawPath(pen, path);
            PointF pointF = new PointF(555, 182);
            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            e.Graphics.DrawString("107", new Font("Microsoft Sans Serif", 8), Brushes.Black, pointF, stringFormat);
            //Araguari - Ind
            e.Graphics.DrawLine(pen, 360, 35, 465, 152);
            e.Graphics.DrawString("62", new Font("Microsoft Sans Serif", 8), Brushes.Black, 422, 83);
            //Vero - Prata
            e.Graphics.DrawLine(pen, 151, 284, 280, 330);
            e.Graphics.DrawString("128", new Font("Microsoft Sans Serif", 8), Brushes.Black, 220, 297);
            //Vero - Ura
            e.Graphics.DrawLine(pen, 425, 284, 345, 323);
            e.Graphics.DrawString("47", new Font("Microsoft Sans Serif", 8), Brushes.Black, 372, 289);
            //Vero - Com
            e.Graphics.DrawLine(pen, 180, 340, 280, 340);
            e.Graphics.DrawString("117", new Font("Microsoft Sans Serif", 8), Brushes.Black, 210, 325);
            //Com - Prata
            e.Graphics.DrawLine(pen, 130, 327, 130, 280);
            e.Graphics.DrawString("69", new Font("Microsoft Sans Serif", 8), Brushes.Black, 110, 303);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ShowLineJoin(e);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
