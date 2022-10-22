using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadcast_Software
{
    public class infoScorebar
    {
        private int id;
        public string scorebarName;
        private Bitmap img;

        // Location
        private PointF prcLocationTeamName1;
        private PointF prcLocationTeamName2;
        private PointF prcLocationScoreTeam1;
        private PointF prcLocationScoreTeam2;
        private PointF prcLocationTime;

        // Font
        private string fontTeamNames;
        private string fontScores;
        private string fontTime;

        // Color
        private string colorTeamNames;
        private string colorScores;
        private string colorTime;

        // Size
        private int sizeTeamName;
        private int sizesScores;
        private int sizeTime;

        public override string ToString()
        {
            return this.scorebarName;
        }

        public infoScorebar(string scorebarName, Bitmap img, PointF prcLocationTeamName1, PointF prcLocationTeamName2, PointF prcLocationScoreTeam1, PointF prcLocationScoreTeam2, PointF prcLocationTime, string fontTeamNames, string fontScores, string fontTime, string colorTeamNames, string colorScores, string colorTime, int sizeTeamName, int sizesScores, int sizeTime)
        {
            this.scorebarName = scorebarName;
            this.img = img;
            this.prcLocationTeamName1 = prcLocationTeamName1;
            this.prcLocationTeamName2 = prcLocationTeamName2;
            this.prcLocationScoreTeam1 = prcLocationScoreTeam1;
            this.prcLocationScoreTeam2 = prcLocationScoreTeam2;
            this.prcLocationTime = prcLocationTime;
            this.fontTeamNames = fontTeamNames;
            this.fontScores = fontScores;
            this.fontTime = fontTime;
            this.colorTeamNames = colorTeamNames;
            this.colorScores = colorScores;
            this.colorTime = colorTime;
            this.sizeTeamName = sizeTeamName;
            this.sizesScores = sizesScores;
            this.sizeTime = sizeTime;
        }

        public infoScorebar(int id, string scorebarName, Bitmap img, PointF prcLocationTeamName1, PointF prcLocationTeamName2, PointF prcLocationScoreTeam1, PointF prcLocationScoreTeam2, PointF prcLocationTime, string fontTeamNames, string fontScores, string fontTime, string colorTeamNames, string colorScores, string colorTime, int sizeTeamName, int sizesScores, int sizeTime)
        {
            this.id = id;
            this.scorebarName = scorebarName;
            this.img = img;
            this.prcLocationTeamName1 = prcLocationTeamName1;
            this.prcLocationTeamName2 = prcLocationTeamName2;
            this.prcLocationScoreTeam1 = prcLocationScoreTeam1;
            this.prcLocationScoreTeam2 = prcLocationScoreTeam2;
            this.prcLocationTime = prcLocationTime;
            this.fontTeamNames = fontTeamNames;
            this.fontScores = fontScores;
            this.fontTime = fontTime;
            this.colorTeamNames = colorTeamNames;
            this.colorScores = colorScores;
            this.colorTime = colorTime;
            this.sizeTeamName = sizeTeamName;
            this.sizesScores = sizesScores;
            this.sizeTime = sizeTime;
        }

        public int Id { get => id; set => id = value; }
        public string ScorebarName { get => scorebarName; set => scorebarName = value; }
        public Bitmap Img { get => img; set => img = value; }
        public PointF PrcLocationTeamName1 { get => prcLocationTeamName1; set => prcLocationTeamName1 = value; }
        public PointF PrcLocationTeamName2 { get => prcLocationTeamName2; set => prcLocationTeamName2 = value; }
        public PointF PrcLocationScoreTeam1 { get => prcLocationScoreTeam1; set => prcLocationScoreTeam1 = value; }
        public PointF PrcLocationScoreTeam2 { get => prcLocationScoreTeam2; set => prcLocationScoreTeam2 = value; }
        public PointF PrcLocationTime { get => prcLocationTime; set => prcLocationTime = value; }
        public string FontTeamNames { get => fontTeamNames; set => fontTeamNames = value; }
        public string FontScores { get => fontScores; set => fontScores = value; }
        public string FontTime { get => fontTime; set => fontTime = value; }
        public string ColorTeamNames { get => colorTeamNames; set => colorTeamNames = value; }
        public string ColorScores { get => colorScores; set => colorScores = value; }
        public string ColorTime { get => colorTime; set => colorTime = value; }
        public int SizeTeamName { get => sizeTeamName; set => sizeTeamName = value; }
        public int SizesScores { get => sizesScores; set => sizesScores = value; }
        public int SizeTime { get => sizeTime; set => sizeTime = value; }
    }

   
}
