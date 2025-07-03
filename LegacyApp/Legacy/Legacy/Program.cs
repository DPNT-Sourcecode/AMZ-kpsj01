using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy
{

    class Program
    {

        public static void Main(string[] args)
        {
            string option1 = "";

            if (args != null && args.Count() == 3 && args[2] != null)
                option1 = args[2];
            string[] option1KV = option1.Split('=');
            Dictionary<string, string> dict = null;
            if (option1KV.Length == 2)
            {
                dict = new Dictionary<string, string>
                {
                    { option1KV[0], option1KV[1] }
                };
            }
            Run(args[0], args[1], dict);
        }

        static int currentLineCharCount = 0;

        static void Print(string variable)
        {
            Console.Write(variable);
            currentLineCharCount += variable.Length;
        }

        static void Print(float variable)
        {
            string text = variable.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)
                        .TrimEnd('0')
                        .TrimEnd('.'); ; // Adjust the format as needed
            Console.Write(text);
            currentLineCharCount += text.Length;
        }

        static void Println()
        {
            Console.WriteLine();
            currentLineCharCount = 0;
        }

        static string Tab(float numSpaces)
        {
            return new string(' ', Math.Max(0, (int)Math.Round(numSpaces - currentLineCharCount)));
        }

        static int AsInt(double variable)
        {
            return (int)Math.Round(variable);
        }

        static float RoundDownToInt(double variable)
        {
            return (float)Math.Floor(variable);
        }

        static float? magicRandomValue = null;
        public static float Random(int dummy)
        {
            if (magicRandomValue.HasValue)
                return magicRandomValue.Value;
            return 0.5f; // fallback default
        }

        static string Mid(string text, float startingIndex, float numChars)
        {
            return text.Substring(
                AsInt(startingIndex - 1),
                AsInt(numChars)
            );
        }

        static float Len(string text)
        {
            return (float)text.Length;
        }

        public static void Run(string width, string length, Dictionary<string, string> mazeGenerationOptions)
        {
            int? entryPosition = null;
            if (mazeGenerationOptions != null && mazeGenerationOptions.ContainsKey("ENTRY_COLUMN"))
            {
                entryPosition = int.Parse(mazeGenerationOptions["ENTRY_COLUMN"]) - 1;
            }

            if (mazeGenerationOptions != null && mazeGenerationOptions.ContainsKey("LEGACY_RANDOM_MAGIC_NUMBER"))
            {
                magicRandomValue = float.Parse(mazeGenerationOptions["LEGACY_RANDOM_MAGIC_NUMBER"]);
            }

            int label = 100;

            float scalarC = 0;
            float scalarH = 0;
            float scalarI = 0;
            float scalarJ = 0;
            float scalarQ = 0;
            float scalarR = 0;
            float scalarS = 0;
            float scalarV = 0;
            float scalarX = 0;
            float scalarZ = 0;
            float[,] matrixV = new float[0, 0];
            float[,] matrixW = new float[0, 0];
            bool loopActive165 = false;
            bool loopActive1017 = false;
            bool loopActive1043 = false;
            bool loopActive1015 = false;

            int iterations = 0;

            while (true)
            {
                iterations = iterations + 1;
                if (iterations > 99999)
                {
                    Print("INFINITE LOOP DETECTED. STOPPING EXECUTION.");
                    //Println();
                    return;
                }

                if (loopActive165 && label > 180) loopActive165 = false;
                if (loopActive1017 && label > 1040) loopActive1017 = false;
                if (loopActive1043 && label > 1070) loopActive1043 = false;
                if (loopActive1015 && label > 1072) loopActive1015 = false;

                switch (label)
                {
                    //10PRINTTAB(28);"AMAZINGPROGRAM"
                    case 10:
                        label = 20;
                        Print(Tab(28)); Print("AMAZING PROGRAM"); Println();
                        break;
                    //20PRINTTAB(15);"CREATIVECOMPUTINGMORRISTOWN,NEWJERSEY"
                    case 20:
                        label = 30;
                        Print(Tab(15)); Print("CREATIVE COMPUTING  MORRISTOWN, NEW JERSEY"); Println();
                        break;
                    //30PRINT:PRINT:PRINT:PRINT
                    case 30:
                        label = 100;
                        Println();
                        Println();
                        Println();
                        Println();
                        break;
                    //100INPUT"WHATAREYOURWIDTHANDLENGTH";H,V
                    case 100:
                        label = 102;
                        //Print("WHAT ARE YOUR WIDTH AND LENGTH");
                        //Println();
                        //scalarH = float.Parse(Console.ReadLine());
                        //scalarV = float.Parse(Console.ReadLine());
                        scalarH = float.Parse(width); //column
                        scalarV = float.Parse(length); //row
                        //if(entryPosition>0 && entryPosition < scalarH)
                        //    scalarH = scalarH - entryPosition;
                        break;
                    //102IFH<>1ANDV<>1THEN110
                    case 102:
                        label = 104;
                        if ((scalarH != 1) && (scalarV != 1))
                        {
                            label = 110;
                        }
                        break;
                    //104PRINT"MEANINGLESSDIMENSIONS.TRYAGAIN.":GOTO100
                    case 104:
                        label = 110;
                        Print("MEANINGLESS DIMENSIONS.  TRY AGAIN."); Println();
                        label = 100;
                        break;
                    //110DIMW(H,V),V(H,V)
                    case 110:
                        label = 120;
                        matrixW = new float[AsInt(scalarH) + 1, AsInt(scalarV) + 1];
                        matrixV = new float[AsInt(scalarH) + 1, AsInt(scalarV) + 1];
                        break;
                    //120PRINT
                    case 120:
                        label = 130;
                        Println();
                        break;
                    //130PRINT
                    case 130:
                        label = 140;
                        Println();
                        break;
                    //140PRINT
                    case 140:
                        label = 150;
                        Println();
                        break;
                    //150PRINT
                    case 150:
                        label = 160;
                        Println();
                        break;
                    //160Q=0:Z=0:X=INT(RND(1)*H+1)
                    case 160:
                        label = 165;
                        scalarQ = 0;
                        scalarZ = 0;
                        //scalarX = RoundDownToInt(Random(1) * scalarH + 1);                        

                        if (entryPosition.HasValue)
                            scalarX = entryPosition.Value + 1; // BASIC-style 1-indexed
                        else
                            scalarX = RoundDownToInt(Random(1) * scalarH + 1); // Original behavior

                        break;
                    //165FORI=1TOH
                    case 165:
                        label = 170;
                        if (loopActive165 == false)
                        {
                            scalarI = 1;
                            loopActive165 = true;
                        }
                        if ((scalarI - scalarH) * 1 > 0)
                        {
                            label = 190;
                        }
                        break;
                    //170IFI=XTHEN173
                    case 170:
                        label = 171;
                        if ((scalarI == scalarX))
                        {
                            label = 173;
                        }
                        break;
                    //171PRINT".--";:GOTO180
                    case 171:
                        label = 173;
                        Print(".--");
                        label = 180;
                        break;
                    //173PRINT".";
                    case 173:
                        label = 180;
                        Print(".  ");
                        break;
                    //180NEXTI
                    case 180:
                        label = 190;
                        scalarI = scalarI + 1;
                        label = 165;
                        break;
                    //190PRINT"."
                    case 190:
                        label = 195;
                        Print("."); Println();
                        break;
                    //195C=1:W(X,1)=C:C=C+1
                    case 195:
                        label = 200;
                        scalarC = 1;
                        matrixW[AsInt(scalarX), AsInt(1)] = scalarC;
                        scalarC = scalarC + 1;
                        break;
                    //200R=X:S=1:GOTO260
                    case 200:
                        label = 210;
                        scalarR = scalarX;
                        scalarS = 1;
                        label = 260;
                        break;
                    //210IFR<>HTHEN240
                    case 210:
                        label = 215;
                        if ((scalarR != scalarH))
                        {
                            label = 240;
                        }
                        break;
                    //215IFS<>VTHEN230
                    case 215:
                        label = 220;
                        if ((scalarS != scalarV))
                        {
                            label = 230;
                        }
                        break;
                    //220R=1:S=1:GOTO250
                    case 220:
                        label = 230;
                        scalarR = 1;
                        scalarS = 1;
                        label = 250;
                        break;
                    //230R=1:S=S+1:GOTO250
                    case 230:
                        label = 240;
                        scalarR = 1;
                        scalarS = scalarS + 1;
                        label = 250;
                        break;
                    //240R=R+1
                    case 240:
                        label = 250;
                        scalarR = scalarR + 1;
                        break;
                    //250IFW(R,S)=0THEN210
                    case 250:
                        label = 260;
                        if ((matrixW[AsInt(scalarR), AsInt(scalarS)] == 0))
                        {
                            label = 210;
                        }
                        break;
                    //260IFR-1=0THEN530
                    case 260:
                        label = 265;
                        if ((scalarR - 1 == 0))
                        {
                            label = 530;
                        }
                        break;
                    //265IFW(R-1,S)<>0THEN530
                    case 265:
                        label = 270;
                        if ((matrixW[AsInt(scalarR - 1), AsInt(scalarS)] != 0))
                        {
                            label = 530;
                        }
                        break;
                    //270IFS-1=0THEN390
                    case 270:
                        label = 280;
                        if ((scalarS - 1 == 0))
                        {
                            label = 390;
                        }
                        break;
                    //280IFW(R,S-1)<>0THEN390
                    case 280:
                        label = 290;
                        if ((matrixW[AsInt(scalarR), AsInt(scalarS - 1)] != 0))
                        {
                            label = 390;
                        }
                        break;
                    //290IFR=HTHEN330
                    case 290:
                        label = 300;
                        if ((scalarR == scalarH))
                        {
                            label = 330;
                        }
                        break;
                    //300IFW(R+1,S)<>0THEN330
                    case 300:
                        label = 310;
                        if ((matrixW[AsInt(scalarR + 1), AsInt(scalarS)] != 0))
                        {
                            label = 330;
                        }
                        break;
                    //310X=INT(RND(1)*3+1)
                    case 310:
                        label = 320;
                        scalarX = RoundDownToInt(Random(1) * 3 + 1);
                        break;
                    //320ONXGOTO790,820,860
                    case 320:
                        label = 330;
                        if (AsInt(scalarX) == 1)
                        {
                            label = 790;
                        }
                        if (AsInt(scalarX) == 2)
                        {
                            label = 820;
                        }
                        if (AsInt(scalarX) == 3)
                        {
                            label = 860;
                        }
                        break;
                    //330IFS<>VTHEN340
                    case 330:
                        label = 334;
                        if ((scalarS != scalarV))
                        {
                            label = 340;
                        }
                        break;
                    //334IFZ=1THEN370
                    case 334:
                        label = 338;
                        if ((scalarZ == 1))
                        {
                            label = 370;
                        }
                        break;
                    //338Q=1:GOTO350
                    case 338:
                        label = 340;
                        scalarQ = 1;
                        label = 350;
                        break;
                    //340IFW(R,S+1)<>0THEN370
                    case 340:
                        label = 350;
                        if ((matrixW[AsInt(scalarR), AsInt(scalarS + 1)] != 0))
                        {
                            label = 370;
                        }
                        break;
                    //350X=INT(RND(1)*3+1)
                    case 350:
                        label = 360;
                        scalarX = RoundDownToInt(Random(1) * 3 + 1);
                        break;
                    //360ONXGOTO790,820,910
                    case 360:
                        label = 370;
                        if (AsInt(scalarX) == 1)
                        {
                            label = 790;
                        }
                        if (AsInt(scalarX) == 2)
                        {
                            label = 820;
                        }
                        if (AsInt(scalarX) == 3)
                        {
                            label = 910;
                        }
                        break;
                    //370X=INT(RND(1)*2+1)
                    case 370:
                        label = 380;
                        scalarX = RoundDownToInt(Random(1) * 2 + 1);
                        break;
                    //380ONXGOTO790,820
                    case 380:
                        label = 390;
                        if (AsInt(scalarX) == 1)
                        {
                            label = 790;
                        }
                        if (AsInt(scalarX) == 2)
                        {
                            label = 820;
                        }
                        break;
                    //390IFR=HTHEN470
                    case 390:
                        label = 400;
                        if ((scalarR == scalarH))
                        {
                            label = 470;
                        }
                        break;
                    //400IFW(R+1,S)<>0THEN470
                    case 400:
                        label = 405;
                        if ((matrixW[AsInt(scalarR + 1), AsInt(scalarS)] != 0))
                        {
                            label = 470;
                        }
                        break;
                    //405IFS<>VTHEN420
                    case 405:
                        label = 410;
                        if ((scalarS != scalarV))
                        {
                            label = 420;
                        }
                        break;
                    //410IFZ=1THEN450
                    case 410:
                        label = 415;
                        if ((scalarZ == 1))
                        {
                            label = 450;
                        }
                        break;
                    //415Q=1:GOTO430
                    case 415:
                        label = 420;
                        scalarQ = 1;
                        label = 430;
                        break;
                    //420IFW(R,S+1)<>0THEN450
                    case 420:
                        label = 430;
                        if ((matrixW[AsInt(scalarR), AsInt(scalarS + 1)] != 0))
                        {
                            label = 450;
                        }
                        break;
                    //430X=INT(RND(1)*3+1)
                    case 430:
                        label = 440;
                        scalarX = RoundDownToInt(Random(1) * 3 + 1);
                        break;
                    //440ONXGOTO790,860,910
                    case 440:
                        label = 450;
                        if (AsInt(scalarX) == 1)
                        {
                            label = 790;
                        }
                        if (AsInt(scalarX) == 2)
                        {
                            label = 860;
                        }
                        if (AsInt(scalarX) == 3)
                        {
                            label = 910;
                        }
                        break;
                    //450X=INT(RND(1)*2+1)
                    case 450:
                        label = 460;
                        scalarX = RoundDownToInt(Random(1) * 2 + 1);
                        break;
                    //460ONXGOTO790,860
                    case 460:
                        label = 470;
                        if (AsInt(scalarX) == 1)
                        {
                            label = 790;
                        }
                        if (AsInt(scalarX) == 2)
                        {
                            label = 860;
                        }
                        break;
                    //470IFS<>VTHEN490
                    case 470:
                        label = 480;
                        if ((scalarS != scalarV))
                        {
                            label = 490;
                        }
                        break;
                    //480IFZ=1THEN520
                    case 480:
                        label = 485;
                        if ((scalarZ == 1))
                        {
                            label = 520;
                        }
                        break;
                    //485Q=1:GOTO500
                    case 485:
                        label = 490;
                        scalarQ = 1;
                        label = 500;
                        break;
                    //490IFW(R,S+1)<>0THEN520
                    case 490:
                        label = 500;
                        if ((matrixW[AsInt(scalarR), AsInt(scalarS + 1)] != 0))
                        {
                            label = 520;
                        }
                        break;
                    //500X=INT(RND(1)*2+1)
                    case 500:
                        label = 510;
                        scalarX = RoundDownToInt(Random(1) * 2 + 1);
                        break;
                    //510ONXGOTO790,910
                    case 510:
                        label = 520;
                        if (AsInt(scalarX) == 1)
                        {
                            label = 790;
                        }
                        if (AsInt(scalarX) == 2)
                        {
                            label = 910;
                        }
                        break;
                    //520GOTO790
                    case 520:
                        label = 530;
                        label = 790;
                        break;
                    //530IFS-1=0THEN670
                    case 530:
                        label = 540;
                        if ((scalarS - 1 == 0))
                        {
                            label = 670;
                        }
                        break;
                    //540IFW(R,S-1)<>0THEN670
                    case 540:
                        label = 545;
                        if ((matrixW[AsInt(scalarR), AsInt(scalarS - 1)] != 0))
                        {
                            label = 670;
                        }
                        break;
                    //545IFR=HTHEN610
                    case 545:
                        label = 547;
                        if ((scalarR == scalarH))
                        {
                            label = 610;
                        }
                        break;
                    //547IFW(R+1,S)<>0THEN610
                    case 547:
                        label = 550;
                        if ((matrixW[AsInt(scalarR + 1), AsInt(scalarS)] != 0))
                        {
                            label = 610;
                        }
                        break;
                    //550IFS<>VTHEN560
                    case 550:
                        label = 552;
                        if ((scalarS != scalarV))
                        {
                            label = 560;
                        }
                        break;
                    //552IFZ=1THEN590
                    case 552:
                        label = 554;
                        if ((scalarZ == 1))
                        {
                            label = 590;
                        }
                        break;
                    //554Q=1:GOTO570
                    case 554:
                        label = 560;
                        scalarQ = 1;
                        label = 570;
                        break;
                    //560IFW(R,S+1)<>0THEN590
                    case 560:
                        label = 570;
                        if ((matrixW[AsInt(scalarR), AsInt(scalarS + 1)] != 0))
                        {
                            label = 590;
                        }
                        break;
                    //570X=INT(RND(1)*3+1)
                    case 570:
                        label = 580;
                        scalarX = RoundDownToInt(Random(1) * 3 + 1);
                        break;
                    //580ONXGOTO820,860,910
                    case 580:
                        label = 590;
                        if (AsInt(scalarX) == 1)
                        {
                            label = 820;
                        }
                        if (AsInt(scalarX) == 2)
                        {
                            label = 860;
                        }
                        if (AsInt(scalarX) == 3)
                        {
                            label = 910;
                        }
                        break;
                    //590X=INT(RND(1)*2+1)
                    case 590:
                        label = 600;
                        scalarX = RoundDownToInt(Random(1) * 2 + 1);
                        break;
                    //600ONXGOTO820,860
                    case 600:
                        label = 610;
                        if (AsInt(scalarX) == 1)
                        {
                            label = 820;
                        }
                        if (AsInt(scalarX) == 2)
                        {
                            label = 860;
                        }
                        break;
                    //610IFS<>VTHEN630
                    case 610:
                        label = 620;
                        if ((scalarS != scalarV))
                        {
                            label = 630;
                        }
                        break;
                    //620IFZ=1THEN660
                    case 620:
                        label = 625;
                        if ((scalarZ == 1))
                        {
                            label = 660;
                        }
                        break;
                    //625Q=1:GOTO640
                    case 625:
                        label = 630;
                        scalarQ = 1;
                        label = 640;
                        break;
                    //630IFW(R,S+1)<>0THEN660
                    case 630:
                        label = 640;
                        if ((matrixW[AsInt(scalarR), AsInt(scalarS + 1)] != 0))
                        {
                            label = 660;
                        }
                        break;
                    //640X=INT(RND(1)*2+1)
                    case 640:
                        label = 650;
                        scalarX = RoundDownToInt(Random(1) * 2 + 1);
                        break;
                    //650ONXGOTO820,910
                    case 650:
                        label = 660;
                        if (AsInt(scalarX) == 1)
                        {
                            label = 820;
                        }
                        if (AsInt(scalarX) == 2)
                        {
                            label = 910;
                        }
                        break;
                    //660GOTO820
                    case 660:
                        label = 670;
                        label = 820;
                        break;
                    //670IFR=HTHEN740
                    case 670:
                        label = 680;
                        if ((scalarR == scalarH))
                        {
                            label = 740;
                        }
                        break;
                    //680IFW(R+1,S)<>0THEN740
                    case 680:
                        label = 685;
                        if ((matrixW[AsInt(scalarR + 1), AsInt(scalarS)] != 0))
                        {
                            label = 740;
                        }
                        break;
                    //685IFS<>VTHEN700
                    case 685:
                        label = 690;
                        if ((scalarS != scalarV))
                        {
                            label = 700;
                        }
                        break;
                    //690IFZ=1THEN730
                    case 690:
                        label = 695;
                        if ((scalarZ == 1))
                        {
                            label = 730;
                        }
                        break;
                    //695Q=1:GOTO710
                    case 695:
                        label = 700;
                        scalarQ = 1;
                        label = 710;
                        break;
                    //700IFW(R,S+1)<>0THEN730
                    case 700:
                        label = 710;
                        if ((matrixW[AsInt(scalarR), AsInt(scalarS + 1)] != 0))
                        {
                            label = 730;
                        }
                        break;
                    //710X=INT(RND(1)*2+1)
                    case 710:
                        label = 720;
                        scalarX = RoundDownToInt(Random(1) * 2 + 1);
                        break;
                    //720ONXGOTO860,910
                    case 720:
                        label = 730;
                        if (AsInt(scalarX) == 1)
                        {
                            label = 860;
                        }
                        if (AsInt(scalarX) == 2)
                        {
                            label = 910;
                        }
                        break;
                    //730GOTO860
                    case 730:
                        label = 740;
                        label = 860;
                        break;
                    //740IFS<>VTHEN760
                    case 740:
                        label = 750;
                        if ((scalarS != scalarV))
                        {
                            label = 760;
                        }
                        break;
                    //750IFZ=1THEN780
                    case 750:
                        label = 755;
                        if ((scalarZ == 1))
                        {
                            label = 780;
                        }
                        break;
                    //755Q=1:GOTO770
                    case 755:
                        label = 760;
                        scalarQ = 1;
                        label = 770;
                        break;
                    //760IFW(R,S+1)<>0THEN780
                    case 760:
                        label = 770;
                        if ((matrixW[AsInt(scalarR), AsInt(scalarS + 1)] != 0))
                        {
                            label = 780;
                        }
                        break;
                    //770GOTO910
                    case 770:
                        label = 780;
                        label = 910;
                        break;
                    //780GOTO1000
                    case 780:
                        label = 790;
                        label = 1000;
                        break;
                    //790W(R-1,S)=C
                    case 790:
                        label = 800;
                        matrixW[AsInt(scalarR - 1), AsInt(scalarS)] = scalarC;
                        break;
                    //800C=C+1:V(R-1,S)=2:R=R-1
                    case 800:
                        label = 810;
                        scalarC = scalarC + 1;
                        matrixV[AsInt(scalarR - 1), AsInt(scalarS)] = 2;
                        scalarR = scalarR - 1;
                        break;
                    //810IFC=H*V+1THEN1010
                    case 810:
                        label = 815;
                        if ((scalarC == scalarH * scalarV + 1))
                        {
                            label = 1010;
                        }
                        break;
                    //815Q=0:GOTO260
                    case 815:
                        label = 820;
                        scalarQ = 0;
                        label = 260;
                        break;
                    //820W(R,S-1)=C
                    case 820:
                        label = 830;
                        matrixW[AsInt(scalarR), AsInt(scalarS - 1)] = scalarC;
                        break;
                    //830C=C+1
                    case 830:
                        label = 840;
                        scalarC = scalarC + 1;
                        break;
                    //840V(R,S-1)=1:S=S-1:IFC=H*V+1THEN1010
                    case 840:
                        label = 850;
                        matrixV[AsInt(scalarR), AsInt(scalarS - 1)] = 1;
                        scalarS = scalarS - 1;
                        if ((scalarC == scalarH * scalarV + 1))
                        {
                            label = 1010;
                        }
                        break;
                    //850Q=0:GOTO260
                    case 850:
                        label = 860;
                        scalarQ = 0;
                        label = 260;
                        break;
                    //860W(R+1,S)=C
                    case 860:
                        label = 870;
                        matrixW[AsInt(scalarR + 1), AsInt(scalarS)] = scalarC;
                        break;
                    //870C=C+1:IFV(R,S)=0THEN880
                    case 870:
                        label = 875;
                        scalarC = scalarC + 1;
                        if ((matrixV[AsInt(scalarR), AsInt(scalarS)] == 0))
                        {
                            label = 880;
                        }
                        break;
                    //875V(R,S)=3:GOTO890
                    case 875:
                        label = 880;
                        matrixV[AsInt(scalarR), AsInt(scalarS)] = 3;
                        label = 890;
                        break;
                    //880V(R,S)=2
                    case 880:
                        label = 890;
                        matrixV[AsInt(scalarR), AsInt(scalarS)] = 2;
                        break;
                    //890R=R+1
                    case 890:
                        label = 900;
                        scalarR = scalarR + 1;
                        break;
                    //900IFC=H*V+1THEN1010
                    case 900:
                        label = 905;
                        if ((scalarC == scalarH * scalarV + 1))
                        {
                            label = 1010;
                        }
                        break;
                    //905GOTO530
                    case 905:
                        label = 910;
                        label = 530;
                        break;
                    //910IFQ=1THEN960
                    case 910:
                        label = 920;
                        if ((scalarQ == 1))
                        {
                            label = 960;
                        }
                        break;
                    //920W(R,S+1)=C:C=C+1:IFV(R,S)=0THEN940
                    case 920:
                        label = 930;
                        matrixW[AsInt(scalarR), AsInt(scalarS + 1)] = scalarC;
                        scalarC = scalarC + 1;
                        if ((matrixV[AsInt(scalarR), AsInt(scalarS)] == 0))
                        {
                            label = 940;
                        }
                        break;
                    //930V(R,S)=3:GOTO950
                    case 930:
                        label = 940;
                        matrixV[AsInt(scalarR), AsInt(scalarS)] = 3;
                        label = 950;
                        break;
                    //940V(R,S)=1
                    case 940:
                        label = 950;
                        matrixV[AsInt(scalarR), AsInt(scalarS)] = 1;
                        break;
                    //950S=S+1:IFC=H*V+1THEN1010
                    case 950:
                        label = 955;
                        scalarS = scalarS + 1;
                        if ((scalarC == scalarH * scalarV + 1))
                        {
                            label = 1010;
                        }
                        break;
                    //955GOTO260
                    case 955:
                        label = 960;
                        label = 260;
                        break;
                    //960Z=1
                    case 960:
                        label = 970;
                        scalarZ = 1;
                        break;
                    //970IFV(R,S)=0THEN980
                    case 970:
                        label = 975;
                        if ((matrixV[AsInt(scalarR), AsInt(scalarS)] == 0))
                        {
                            label = 980;
                        }
                        break;
                    //975V(R,S)=3:Q=0:GOTO1000
                    case 975:
                        label = 980;
                        matrixV[AsInt(scalarR), AsInt(scalarS)] = 3;
                        scalarQ = 0;
                        label = 1000;
                        break;
                    //980V(R,S)=1:Q=0:R=1:S=1:GOTO250
                    case 980:
                        label = 1000;
                        matrixV[AsInt(scalarR), AsInt(scalarS)] = 1;
                        scalarQ = 0;
                        scalarR = 1;
                        scalarS = 1;
                        label = 250;
                        break;
                    //1000GOTO210
                    case 1000:
                        label = 1010;
                        label = 210;
                        break;
                    //1010IFZ=1THEN1015
                    case 1010:
                        label = 1011;
                        if ((scalarZ == 1))
                        {
                            label = 1015;
                        }
                        break;
                    //1011X=INT(RND(1)*H+1)
                    case 1011:
                        label = 1012;
                        scalarX = RoundDownToInt(Random(1) * scalarH + 1);
                        break;
                    //1012IFV(X,V)=0THEN1014
                    case 1012:
                        label = 1013;
                        if ((matrixV[AsInt(scalarX), AsInt(scalarV)] == 0))
                        {
                            label = 1014;
                        }
                        break;
                    //1013V(X,V)=3:GOTO1015
                    case 1013:
                        label = 1014;
                        matrixV[AsInt(scalarX), AsInt(scalarV)] = 3;
                        label = 1015;
                        break;
                    //1014V(X,V)=1
                    case 1014:
                        label = 1015;
                        matrixV[AsInt(scalarX), AsInt(scalarV)] = 1;
                        break;
                    //1015FORJ=1TOV
                    case 1015:
                        label = 1016;
                        if (loopActive1015 == false)
                        {
                            scalarJ = 1;
                            loopActive1015 = true;
                        }
                        if ((scalarJ - scalarV) * 1 > 0)
                        {
                            label = 1073;
                        }
                        break;
                    //1016PRINT"I";
                    case 1016:
                        label = 1017;
                        Print("I");
                        break;
                    //1017FORI=1TOH
                    case 1017:
                        label = 1018;
                        if (loopActive1017 == false)
                        {
                            scalarI = 1;
                            loopActive1017 = true;
                        }
                        if ((scalarI - scalarH) * 1 > 0)
                        {
                            label = 1041;
                        }
                        break;
                    //1018IFV(I,J)<2THEN1030
                    case 1018:
                        label = 1020;
                        if ((matrixV[AsInt(scalarI), AsInt(scalarJ)] < 2))
                        {
                            label = 1030;
                        }
                        break;
                    //1020PRINT"";
                    case 1020:
                        label = 1021;
                        Print("   ");
                        break;
                    //1021GOTO1040
                    case 1021:
                        label = 1030;
                        label = 1040;
                        break;
                    //1030PRINT"I";
                    case 1030:
                        label = 1040;
                        Print("  I");
                        break;
                    //1040NEXTI
                    case 1040:
                        label = 1041;
                        scalarI = scalarI + 1;
                        label = 1017;
                        break;
                    //1041PRINT
                    case 1041:
                        label = 1043;
                        Println();
                        break;
                    //1043FORI=1TOH
                    case 1043:
                        label = 1045;
                        if (loopActive1043 == false)
                        {
                            scalarI = 1;
                            loopActive1043 = true;
                        }
                        if ((scalarI - scalarH) * 1 > 0)
                        {
                            label = 1071;
                        }
                        break;
                    //1045IFV(I,J)=0THEN1060
                    case 1045:
                        label = 1050;
                        if ((matrixV[AsInt(scalarI), AsInt(scalarJ)] == 0))
                        {
                            label = 1060;
                        }
                        break;
                    //1050IFV(I,J)=2THEN1060
                    case 1050:
                        label = 1051;
                        if ((matrixV[AsInt(scalarI), AsInt(scalarJ)] == 2))
                        {
                            label = 1060;
                        }
                        break;
                    //1051PRINT":";
                    case 1051:
                        label = 1052;
                        Print(":  ");
                        break;
                    //1052GOTO1070
                    case 1052:
                        label = 1060;
                        label = 1070;
                        break;
                    //1060PRINT":--";
                    case 1060:
                        label = 1070;
                        Print(":--");
                        break;
                    //1070NEXTI
                    case 1070:
                        label = 1071;
                        scalarI = scalarI + 1;
                        label = 1043;
                        break;
                    //1071PRINT"."
                    case 1071:
                        label = 1072;
                        Print("."); Println();
                        break;
                    //1072NEXTJ
                    case 1072:
                        label = 1073;
                        scalarJ = scalarJ + 1;
                        label = 1015;
                        break;
                    //1073END
                    case 1073:
                        label = 9999;
                        label = 9999;
                        break;
                    case 9999:
                        return;
                    default:
                        throw new ArgumentException($"The label {label} is not recognized.");
                }
            }
        }
    }
}

