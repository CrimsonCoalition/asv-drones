﻿namespace Asv.Drones.Gui.Sdr;

public static class SdrRttHelper
{
    public static string GetVorChannelFromVorFrequency(ulong frequency)
    {
        switch (frequency)
        {
            case 108_000_000:
                return "17X";
            case 108_050_000:
                return "17Y";
            case 108_200_000:
                return "19X";
            case 108_250_000:
                return "19Y";
            case 108_400_000:
                return "21X";
            case 108_450_000:
                return "21Y";
            case 108_600_000:
                return "23X";
            case 108_650_000:
                return "23Y";
            case 108_800_000:
                return "25X";
            case 108_850_000:
                return "25Y";
            case 109_000_000:
                return "27X";
            case 109_050_000:
                return "27Y";
            case 109_200_000:
                return "29X";
            case 109_250_000:
                return "29Y";
            case 109_400_000:
                return "31X";
            case 109_450_000:
                return "31Y";
            case 109_600_000:
                return "33X";
            case 109_650_000:
                return "33Y";
            case 109_800_000:
                return "35X";
            case 109_850_000:
                return "35Y";
            case 110_000_000:
                return "37X";
            case 110_050_000:
                return "37Y";
            case 110_200_000:
                return "39X";
            case 110_250_000:
                return "39Y";
            case 110_400_000:
                return "41X";
            case 110_450_000:
                return "41Y";
            case 110_600_000:
                return "43X";
            case 110_650_000:
                return "43Y";
            case 110_800_000:
                return "45X";
            case 110_850_000:
                return "45Y";
            case 111_000_000:
                return "47X";
            case 111_050_000:
                return "47Y";
            case 111_200_000:
                return "49X";
            case 111_250_000:
                return "49Y";
            case 111_400_000:
                return "51X";
            case 111_450_000:
                return "51Y";
            case 111_600_000:
                return "53X";
            case 111_650_000:
                return "53Y";
            case 111_800_000:
                return "55X";
            case 111_850_000:
                return "55Y";
            case 112_000_000:
                return "57X";
            case 112_050_000:
                return "57Y";
            case 112_100_000:
                return "58X";
            case 112_150_000:
                return "58Y";
            case 112_200_000:
                return "59X";
            case 112_250_000:
                return "59Y";
            case 112_300_000:
                return "70X";
            case 112_350_000:
                return "70Y";
            case 112_400_000:
                return "71X";
            case 112_450_000:
                return "71Y";
            case 112_500_000:
                return "72X";
            case 112_550_000:
                return "72Y";
            case 112_600_000:
                return "73X";
            case 112_650_000:
                return "73Y";
            case 112_700_000:
                return "74X";
            case 112_750_000:
                return "74Y";
            case 112_800_000:
                return "75X";
            case 112_850_000:
                return "75Y";
            case 112_900_000:
                return "76X";
            case 112_950_000:
                return "76Y";
            case 113_000_000:
                return "77X";
            case 113_050_000:
                return "77Y";
            case 113_100_000:
                return "78X";
            case 113_150_000:
                return "78Y";
            case 113_200_000:
                return "79X";
            case 113_250_000:
                return "79Y";
            case 113_300_000:
                return "80X";
            case 113_350_000:
                return "80Y";
            case 113_400_000:
                return "81X";
            case 113_450_000:
                return "81Y";
            case 113_500_000:
                return "82X";
            case 113_550_000:
                return "82Y";
            case 113_600_000:
                return "83X";
            case 113_650_000:
                return "83Y";
            case 113_700_000:
                return "84X";
            case 113_750_000:
                return "84Y";
            case 113_800_000:
                return "85X";
            case 113_850_000:
                return "85Y";
            case 113_900_000:
                return "86X";
            case 113_950_000:
                return "86Y";
            case 114_000_000:
                return "87X";
            case 114_050_000:
                return "87Y";
            case 114_100_000:
                return "88X";
            case 114_150_000:
                return "88Y";
            case 114_200_000:
                return "89X";
            case 114_250_000:
                return "89Y";
            case 114_300_000:
                return "90X";
            case 114_350_000:
                return "90Y";
            case 114_400_000:
                return "91X";
            case 114_450_000:
                return "91Y";
            case 114_500_000:
                return "92X";
            case 114_550_000:
                return "92Y";
            case 114_600_000:
                return "93X";
            case 114_650_000:
                return "93Y";
            case 114_700_000:
                return "94X";
            case 114_750_000:
                return "94Y";
            case 114_800_000:
                return "95X";
            case 114_850_000:
                return "95Y";
            case 114_900_000:
                return "96X";
            case 114_950_000:
                return "96Y";
            case 115_000_000:
                return "97X";
            case 115_050_000:
                return "97Y";
            case 115_100_000:
                return "98X";
            case 115_150_000:
                return "98Y";
            case 115_200_000:
                return "99X";
            case 115_250_000:
                return "99Y";
            case 115_300_000:
                return "100X";
            case 115_350_000:
                return "100Y";
            case 115_400_000:
                return "101X";
            case 115_450_000:
                return "101Y";
            case 115_500_000:
                return "102X";
            case 115_550_000:
                return "102Y";
            case 115_600_000:
                return "103X";
            case 115_650_000:
                return "103Y";
            case 115_700_000:
                return "104X";
            case 115_750_000:
                return "104Y";
            case 115_800_000:
                return "105X";
            case 115_850_000:
                return "105Y";
            case 115_900_000:
                return "106X";
            case 115_950_000:
                return "106Y";
            case 116_000_000:
                return "107X";
            case 116_050_000:
                return "107Y";
            case 116_100_000:
                return "108X";
            case 116_150_000:
                return "108Y";
            case 116_200_000:
                return "109X";
            case 116_250_000:
                return "109Y";
            case 116_300_000:
                return "110X";
            case 116_350_000:
                return "110Y";
            case 116_400_000:
                return "111X";
            case 116_450_000:
                return "111Y";
            case 116_500_000:
                return "112X";
            case 116_550_000:
                return "112Y";
            case 116_600_000:
                return "113X";
            case 116_650_000:
                return "113Y";
            case 116_700_000:
                return "114X";
            case 116_750_000:
                return "114Y";
            case 116_800_000:
                return "115X";
            case 116_850_000:
                return "115Y";
            case 116_900_000:
                return "116X";
            case 116_950_000:
                return "116Y";
            case 117_000_000:
                return "117X";
            case 117_050_000:
                return "117Y";
            case 117_100_000:
                return "118X";
            case 117_150_000:
                return "118Y";
            case 117_200_000:
                return "119X";
            case 117_250_000:
                return "119Y";
            case 117_300_000:
                return "120X";
            case 117_350_000:
                return "120Y";
            case 117_400_000:
                return "121X";
            case 117_450_000:
                return "121Y";
            case 117_500_000:
                return "122X";
            case 117_550_000:
                return "122Y";
            case 117_600_000:
                return "123X";
            case 117_650_000:
                return "123Y";
            case 117_700_000:
                return "124X";
            case 117_750_000:
                return "124Y";
            case 117_800_000:
                return "125X";
            case 117_850_000:
                return "125Y";
            case 117_900_000:
                return "126X";
            case 117_950_000:
                return "126Y";
        }
        return RS.LLzSdrRttViewModel_ValueNotAvailable;
    }
    
    public static string GetIlsChannelFromLocalizerModeFrequency(ulong frequency)
    {
        switch (frequency)
        {
            case 108_100_000:
                return "18X";
            case 108_150_000:
                return "18Y";
            case 108_300_000:
                return "20X";
            case 108_350_000:
                return "20Y";
            case 108_500_000:
                return "22X";
            case 108_550_000:
                return "22Y";
            case 108_700_000:
                return "24X";
            case 108_750_000:
                return "24Y";
            case 108_900_000:
                return "26X";
            case 108_950_000:
                return "26Y";
            case 109_100_000:
                return "28X";
            case 109_150_000:
                return "28Y";
            case 109_300_000:
                return "30X";
            case 109_350_000:
                return "30Y";
            case 109_500_000:
                return "32X";
            case 109_550_000:
                return "32Y";
            case 109_700_000:
                return "34X";
            case 109_750_000:
                return "34Y";
            case 109_900_000:
                return "36X";
            case 109_950_000:
                return "36Y";
            case 110_100_000:
                return "38X";
            case 110_150_000:
                return "38Y";
            case 110_300_000:
                return "40X";
            case 110_350_000:
                return "40Y";
            case 110_500_000:
                return "42X";
            case 110_550_000:
                return "42Y";
            case 110_700_000:
                return "44X";
            case 110_750_000:
                return "44Y";
            case 110_900_000:
                return "46X";
            case 110_950_000:
                return "46Y";
            case 111_100_000:
                return "48X";
            case 111_150_000:
                return "48Y";
            case 111_300_000:
                return "50X";
            case 111_350_000:
                return "50Y";
            case 111_500_000:
                return "52X";
            case 111_550_000:
                return "52Y";
            case 111_700_000:
                return "54X";
            case 111_750_000:
                return "54Y";
            case 111_900_000:
                return "56X";
            case 111_950_000:
                return "56Y";
        }
        return RS.LLzSdrRttViewModel_ValueNotAvailable;
    }
    
    public static string GetIlsChannelFromGlidepathModeFrequency(ulong frequency)
    {
        switch (frequency)
        {
            case 334_700_000:
                return "18X";
            case 334_550_000:
                return "18Y";
            case 334_100_000:
                return "20X";
            case 333_950_000:
                return "20Y";
            case 329_900_000:
                return "22X";
            case 329_750_000:
                return "22Y";
            case 330_500_000:
                return "24X";
            case 330_350_000:
                return "24Y";
            case 329_300_000:
                return "26X";
            case 329_150_000:
                return "26Y";
            case 331_400_000:
                return "28X";
            case 331_250_000:
                return "28Y";
            case 332_000_000:
                return "30X";
            case 331_850_000:
                return "30Y";
            case 332_600_000:
                return "32X";
            case 332_450_000:
                return "32Y";
            case 333_200_000:
                return "34X";
            case 333_050_000:
                return "34Y";
            case 333_800_000:
                return "36X";
            case 333_650_000:
                return "36Y";
            case 334_400_000:
                return "38X";
            case 334_250_000:
                return "38Y";
            case 335_000_000:
                return "40X";
            case 334_850_000:
                return "40Y";
            case 329_600_000:
                return "42X";
            case 329_450_000:
                return "42Y";
            case 330_200_000:
                return "44X";
            case 330_050_000:
                return "44Y";
            case 330_800_000:
                return "46X";
            case 330_650_000:
                return "46Y";
            case 331_700_000:
                return "48X";
            case 331_550_000:
                return "48Y";
            case 332_300_000:
                return "50X";
            case 332_150_000:
                return "50Y";
            case 332_900_000:
                return "52X";
            case 332_750_000:
                return "52Y";
            case 333_500_000:
                return "54X";
            case 333_350_000:
                return "54Y";
            case 331_100_000:
                return "56X";
            case 330_950_000:
                return "56Y";
        }
        return RS.LLzSdrRttViewModel_ValueNotAvailable;
    }
    
}