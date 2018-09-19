using SRB_Rail_Timetable.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRB_Rail_Timetable.Logic
{
    /// <summary>
    /// Helps with creation of TimetableEntry.
    /// </summary>
    public static class TimetableEntryHelper
    {
        #region Stations And IDs

        public static Dictionary<string, string> StationsAndIds = new Dictionary<string, string>()
        {
            { "ADRANI", "13001"  },
            { "ADROVAC", "12509"  },
            { "ALEKSA SANTIC", "24403"  },
            { "ALEKSANDROVO PREDGRADE", "23410"  },
            { "ALEKSINAC", "12510"  },
            { "ALIBUNAR", "21004"  },
            { "BABIN POTOK", "11124"  },
            { "BACKA TOPOLA", "23404"  },
            { "BACKI MAGLIC", "24005"  },
            { "BAD GASTEIN", "02807"  },
            { "BAD HOFGASTEIN", "02806"  },
            { "BADNJEVAC", "13203"  },
            { "BAGRDAN", "13303"  },
            { "BAJMOK", "24404"  },
            { "BALOTSZALLAS", "16329"  },
            { "BALUGA", "13012"  },
            { "BANAT.MILOSEVO POLJE", "22508"  },
            { "BANATSKI KARLOVAC", "21005"  },
            { "BANATSKO MILOSEVO", "22509"  },
            { "BANATSKO NOVO SELO", "21002"  },
            { "BANJSKA", "12006"  },
            { "BANOVA JARUGA", "02644"  },
            { "BAR", "31080"  },
            { "BARAJEVO CENTAR", "15204"  },
            { "BARLOVO", "11111"  },
            { "BATAJNICA", "16204"  },
            { "BATOCINA", "13201"  },
            { "BELA PALANKA", "12413"  },
            { "BELA REKA", "15201"  },
            { "BELANOVAC", "12412"  },
            { "BELOLJIN", "11109"  },
            { "BELOTINCE", "12302"  },
            { "BEOGRAD CENTAR", "16052"  },
            { "BESKA", "16802"  },
            { "BIJELO BRDO", "04252"  },
            { "BIJELO POLJE", "31302"  },
            { "BISTRICA NA LIMU", "15710"  },
            { "BOCAR", "22601"  },
            { "BOGARAS", "23803"  },
            { "BOGOJEVO", "25470"  },
            { "BOGOJEVO SELO", "25403"  },
            { "BOGUTOVACKA BANJA", "12103"  },
            { "BOR", "14350"  },
            { "BOR TERETNA", "14305"  },
            { "BORACKO", "13011"  },
            { "BORSKA SLATINA", "14304"  },
            { "BOSZTOR", "16212"  },
            { "BOZURAT", "12421"  },
            { "BRALJINA", "12502"  },
            { "BRANESCI", "15703"  },
            { "BRESNICICI", "11108"  },
            { "BRESTOVAC", "11004"  },
            { "BREZONIK", "14413"  },
            { "BRODAREVO", "15714"  },
            { "BRUSNIK", "14106"  },
            { "BRVENIK", "12109"  },
            { "BRZAN", "13301"  },
            { "BUDANOVCI", "16601"  },
            { "BUDAPEST KELENFOELD", "01024"  },
            { "BUDAPEST KELENFOLD", "04934"  },
            { "BUDAPEST KELETI PU.", "04930"  },
            { "BUJANOVAC", "11024"  },
            { "BUKOVACKI SALASI", "25503"  },
            { "BUKOVCE", "13305"  },
            { "CACAK", "13060"  },
            { "CAPLJINAC", "12304"  },
            { "CELE KULA", "12402"  },
            { "CEROVO", "14405"  },
            { "CEROVO RAZANJ", "12517"  },
            { "CICEVAC", "13313"  },
            { "CIFLIK", "12415"  },
            { "CINIGLAVCI", "12424"  },
            { "CITLUK", "12218"  },
            { "COKA", "22605"  },
            { "COKONJAR", "14102"  },
            { "CONOPLJA", "24207"  },
            { "CORTANOVCI", "16803"  },
            { "CREPAJA", "22004"  },
            { "CRKVICA", "12414"  },
            { "CRNOMASNICA", "14108"  },
            { "CRVENA REKA", "12411"  },
            { "CRVENCEVO", "12427"  },
            { "CRVENI BREG", "12426"  },
            { "CRVENI KRST", "12550"  },
            { "CRVENKA", "24203"  },
            { "CSENGOD", "16253"  },
            { "CUPRIJA", "13351"  },
            { "DALJ", "04251"  },
            { "DEBELI LUG", "14410"  },
            { "DEBELJACA", "22005"  },
            { "DEDINA", "12203"  },
            { "DEMIR KAPIJA", "09836"  },
            { "DESISKA", "11127"  },
            { "DIMITROVGRAD", "12499"  },
            { "DIVCI", "15213"  },
            { "DOBOVA", "02660"  },
            { "DOBRE STRANE", "12104"  },
            { "DOLAC", "12410"  },
            { "DOLINE", "23804"  },
            { "DOLJEVAC", "11001"  },
            { "DONJE JARINJE", "12117"  },
            { "DONJE ZUNICE", "14015"  },
            { "DONJI LJUBES", "12506"  },
            { "DORDEVO", "11010"  },
            { "DRAGACEVO", "13009"  },
            { "DRAGOBRACA", "13211"  },
            { "DREN", "12002"  },
            { "DRENOVAC", "13312"  },
            { "DRENOVACKI KIK", "15104"  },
            { "DUBLJE MACVANSKO STAJ", "16302"  },
            { "DUGO SELO", "02650"  },
            { "DUNIS", "12504"  },
            { "DURDEVO POLJE", "12417"  },
            { "DZEP", "11014"  },
            { "DZUROVO", "15718"  },
            { "ELEMIR", "22503"  },
            { "ERDUT", "04232"  },
            { "FERENCVAROS", "04933"  },
            { "FÜLÖPSZALLAS", "16238"  },
            { "FUTOG", "24003"  },
            { "GAJDOBRA", "24001"  },
            { "GEVGELIJA", "09840"  },
            { "GILJE", "13307"  },
            { "GLIBOVAC", "13705"  },
            { "GLUMAC", "15113"  },
            { "GODOMIN", "13602"  },
            { "GOLUBINCI", "16505"  },
            { "GORICANI", "13004"  },
            { "GORNJA DRAGANJA", "08409"  },
            { "GORNJANE", "14408"  },
            { "GORNJE ZUNICE", "14014"  },
            { "GORNJI BREG", "23802"  },
            { "GORNJI LJUBES", "12519"  },
            { "GRAD STALAC STA", "12219"  },
            { "GRADAC", "13202"  },
            { "GRAMADA", "14005"  },
            { "GRDELICA", "11011"  },
            { "GREJAC", "12513"  },
            { "GRLJAN", "14021"  },
            { "GROSNICA", "13210"  },
            { "GRUZA", "13214"  },
            { "GUBEREVAC", "13215"  },
            { "GUGALJ", "13015"  },
            { "GYOR", "01289"  },
            { "HADZICEVO", "14006"  },
            { "HEGYESHALOM", "01362"  },
            { "IBARSKA SLATINA", "12005"  },
            { "INDIJA", "16801"  },
            { "INDIJA PUSTARA", "16518"  },
            { "IVANIC GRAD", "02648"  },
            { "IVERAK", "15215"  },
            { "JABLANICA", "15706"  },
            { "JADARSKA STRAZA", "16308"  },
            { "JAGODINA", "13350"  },
            { "JASENICA", "11102"  },
            { "JASENOVIK", "14004"  },
            { "JASIKOVO", "14403"  },
            { "JELEN DO", "13013"  },
            { "JERINA STAJ", "12114"  },
            { "JESENICE", "02716"  },
            { "JIMBOLIA", "05129"  },
            { "JOSANICKA BANJA", "12107"  },
            { "JOVANOVAC", "13207"  },
            { "KACAREVO", "22003"  },
            { "KALENIC", "15107"  },
            { "KARADORDEV PARK", "16053"  },
            { "KARAVUKOVO", "25402"  },
            { "KARLOVACKI VINOGRADI", "16805"  },
            { "KASTRAT", "11114"  },
            { "KAZNOVICI", "12112"  },
            { "KELEBIJA", "04137"  },
            { "KIJEVO", "16101"  },
            { "KIKINDA", "22850"  },
            { "KISAC", "23302"  },
            { "KISKOROS", "04914"  },
            { "KISKUNHALAS", "04910"  },
            { "KISSZALLAS", "16337"  },
            { "KLENAK", "16604"  },
            { "KLJAJICEVO", "24206"  },
            { "KNEZEVAC", "16102"  },
            { "KNIC", "13213"  },
            { "KNJAZEVAC", "14013"  },
            { "KOBISNICA", "14113"  },
            { "KOCANE", "11002"  },
            { "KOLASIN", "31307"  },
            { "KORMAN", "12507"  },
            { "KOSANCIC IVAN", "11117"  },
            { "KOSANICA", "11123"  },
            { "KOSANICKA RACA", "11116"  },
            { "KOSEVI", "12205"  },
            { "KOSJERIC", "15106"  },
            { "KOSOVSKA MITROVICA SEVER", "12022"  },
            { "KOVACEVAC", "13701"  },
            { "KOVACICA", "22006"  },
            { "KRAGUJEVAC", "13250"  },
            { "KRALJEVCI", "16507"  },
            { "KRALJEVO", "13251"  },
            { "KRANJ", "02712"  },
            { "KRIVELJSKI MOST", "14409"  },
            { "KRIVELJSKI POTOK", "14406"  },
            { "KRNJACA", "16015"  },
            { "KRNJACA MOST", "16016"  },
            { "KRNJEVO-TRNOVCE", "13506"  },
            { "KRUSEVAC", "12204"  },
            { "KUKICI", "13014"  },
            { "KUKUJEVCI-ERDEVIK", "16513"  },
            { "KULA", "24202"  },
            { "KUMANE", "22505"  },
            { "KUMANOVO", "09805"  },
            { "KUNSZENTMIKLOS TASS", "04920"  },
            { "KURSUMLIJA", "11113"  },
            { "KUSADAK", "13703"  },
            { "KUTINA", "02646"  },
            { "LAJKOVAC", "15260"  },
            { "LANISTE", "13304"  },
            { "LAPOVO", "13450"  },
            { "LAPOVO RANZ.STAJ.", "09125"  },
            { "LAPOVO VAROS", "13405"  },
            { "LASTRA", "15102"  },
            { "LAZAREVAC", "15209"  },
            { "LEPENICKI MOST", "11018"  },
            { "LEPOSAVIC", "12003"  },
            { "LESAK", "12001"  },
            { "LESKOVAC", "11050"  },
            { "LESKOVICE", "15112"  },
            { "LESKOVO", "14402"  },
            { "LESNICA", "16307"  },
            { "LIPNICA", "16309"  },
            { "LIPOVA STA", "12212"  },
            { "LIPOVICA", "11005"  },
            { "LITIJA", "02708"  },
            { "LJUBICEVSKI MOST", "14551"  },
            { "LJUBLJANA", "02710"  },
            { "LJUSA", "11125"  },
            { "LJUTOVO", "24407"  },
            { "LOVCENAC", "23401"  },
            { "LOZNICA", "16310"  },
            { "LOZNO", "12115"  },
            { "LOZOVIK-SARAORCI", "13504"  },
            { "LUCICE", "15713"  },
            { "LUCINA", "13314"  },
            { "LUGAVCINA", "13508"  },
            { "LUKICEVO", "22204"  },
            { "LUKOMIR", "11119"  },
            { "LUZANE", "12511"  },
            { "MAJDANPEK", "14401"  },
            { "MAJUR", "02219"  },
            { "MALA KRSNA", "13551"  },
            { "MALA PLANA", "13707"  },
            { "MALI IDOS POLJE", "23403"  },
            { "MALI IDOS STAJ.", "23402"  },
            { "MALI IZVOR", "14018"  },
            { "MALI KRIVELJ", "14407"  },
            { "MALLNITZ-OBERVELLACH", "02808"  },
            { "MALOSISTE", "12303"  },
            { "MARKOVAC", "13404"  },
            { "MARTINCI", "16511"  },
            { "MATARUSKA BANJA", "12101"  },
            { "MATEJEVAC", "14001"  },
            { "MEDUROVO", "12301"  },
            { "MELENCI", "22504"  },
            { "MERDARE", "11118"  },
            { "MEZGRAJA", "12515"  },
            { "MILATOVAC", "13205"  },
            { "MILAVCICI", "13217"  },
            { "MILOSEVAC", "13505"  },
            { "MILOSEVO", "13302"  },
            { "MINICEVO", "14016"  },
            { "MLADENOVAC", "15460"  },
            { "MLADEVO", "15212"  },
            { "MOJKOVAC", "31305"  },
            { "MOMIN KAMEN", "11015"  },
            { "MOSONMAGYAROVAR", "01347"  },
            { "MRSAC", "13002"  },
            { "MRSINCI", "13005"  },
            { "MRZENICA", "12201"  },
            { "NAUMOVICEVO", "23409"  },
            { "NEGOTIN", "14114"  },
            { "NEGOTINO VARDAR", "09835"  },
            { "NIKINCI", "16602"  },
            { "NIKOLINCI", "21006"  },
            { "NIS", "12551"  },
            { "NISEVAC", "14008"  },
            { "NISKA BANJA", "12404"  },
            { "NOVA KAPELA BATRINA", "02636"  },
            { "NOVA PAZOVA", "16501"  },
            { "NOVI BECEJ", "22506"  },
            { "NOVI BEOGRAD", "16003"  },
            { "NOVI SAD", "16808"  },
            { "NOVO SELO", "13403"  },
            { "NOVSKA", "02642"  },
            { "NOZRINA", "12520"  },
            { "ODZACI", "25003"  },
            { "ODZACI KALVARIJA", "25401"  },
            { "ORLOVAT STAJALISTE", "22203"  },
            { "OROM", "23805"  },
            { "OSIJEK", "04258"  },
            { "OSIJEK DONJI GRAD", "04256"  },
            { "OSIJEK LUKA", "04254"  },
            { "OSIJEK OLT", "04257"  },
            { "OSIPAONICA", "13503"  },
            { "OSIPAONICA STAJ.", "13501"  },
            { "OSTOJICEVO", "22604"  },
            { "OSTROVICA", "12407"  },
            { "OTANJ", "15116"  },
            { "OVCA", "16007"  },
            { "OVCAR BANJA", "13008"  },
            { "PADEJ", "22603"  },
            { "PALANKA", "13706"  },
            { "PALILULA", "14009"  },
            { "PALILULSKA RAMPA", "12401"  },
            { "PALOJSKA ROSULJA", "11012"  },
            { "PANCEVACKI MOST", "16013"  },
            { "PANCEVO GLAVNA", "22001"  },
            { "PANCEVO STRELISTE", "16014"  },
            { "PANCEVO VAROS", "21010"  },
            { "PANCEVO VOJLOVICA", "21101"  },
            { "PANTELEJ", "14003"  },
            { "PARACIN", "13310"  },
            { "PARAGE", "25001"  },
            { "PECENJEVCE", "11006"  },
            { "PEPELJEVAC", "11112"  },
            { "PESTERZSEBET mh", "10314"  },
            { "PETLOVACA", "16303"  },
            { "PETROVAC-GLOZAN", "24004"  },
            { "PETROVARADIN", "16807"  },
            { "PIROT", "12420"  },
            { "PIRTOI SZOLOK mh.", "16295"  },
            { "PISKANJA", "12108"  },
            { "PLANDISTE", "12019"  },
            { "PLATICEVO", "16603"  },
            { "PLOCNIK", "11110"  },
            { "POCEKOVINA", "12208"  },
            { "PODGORICA", "31001"  },
            { "PODINA", "11105"  },
            { "PODRINJSKO NOVO SELO", "16306"  },
            { "PODUNAVCI", "12213"  },
            { "PODVIS", "14011"  },
            { "POLJICE", "15722"  },
            { "POLUMIR", "12105"  },
            { "POZAREVAC", "14550"  },
            { "POZEGA", "15150"  },
            { "PRAHOVO", "14115"  },
            { "PRAHOVO PRISTANISTE", "14170"  },
            { "PREDEJANE", "11013"  },
            { "PRESEVO", "11027"  },
            { "PRIBOJ", "15708"  },
            { "PRIBOJ LESKOVACKI", "11009"  },
            { "PRIBOJ VRANJSKI", "11019"  },
            { "PRIBOJSKA BANJA", "15709"  },
            { "PRIDVORICA", "12021"  },
            { "PRIGREVICA", "25502"  },
            { "PRIJEPOLJE", "15711"  },
            { "PRIJEPOLJE TERETNA", "15712"  },
            { "PRIJEVOR", "13007"  },
            { "PRNJAVOR MACVANSKI", "16305"  },
            { "PROGORELICA", "12102"  },
            { "PROKUPLJE", "11106"  },
            { "PROSEK", "12405"  },
            { "PUKOVAC", "11003"  },
            { "PUSTO POLJE", "12116"  },
            { "PUTINCI", "16506"  },
            { "RABROVAC", "13702"  },
            { "RADINAC", "13603"  },
            { "RADOV DOL", "12409"  },
            { "RAJAC", "14109"  },
            { "RAKOVICA", "16103"  },
            { "RALJA", "15405"  },
            { "RASKA", "12111"  },
            { "RASNA", "15111"  },
            { "Rasputnica Kastrat", "08319"  },
            { "RATARE", "13704"  },
            { "RATINA", "12215"  },
            { "RATKOVO", "25002"  },
            { "RAZANA", "15105"  },
            { "RECICA", "11104"  },
            { "RESNIK", "15501"  },
            { "RGOSTE", "14012"  },
            { "RGOTINA", "14302"  },
            { "RIBARI STAJ", "16304"  },
            { "RIBNICA ZLATIBORSKA", "15705"  },
            { "RIPANJ", "15402"  },
            { "RISTANOVICA POLJE", "15716"  },
            { "RISTOVAC", "11023"  },
            { "ROGLJEVO", "14110"  },
            { "RUDARE", "11115"  },
            { "RUDNICA", "12113"  },
            { "RUMA", "16550"  },
            { "RVATI", "12110"  },
            { "SABAC", "16350"  },
            { "SAJINOVAC", "11101"  },
            { "SAMAILA", "13003"  },
            { "SAMARI", "15103"  },
            { "SARAORCI", "13510"  },
            { "SARVAS", "04253"  },
            { "SCHWARZACH ST.VEIT", "02812"  },
            { "SEBES", "16006"  },
            { "SEBESIC", "24408"  },
            { "SELACKA REKA", "14017"  },
            { "SENTA", "23801"  },
            { "SEVOJNO", "15108"  },
            { "SICEVO", "12406"  },
            { "SID", "16516"  },
            { "SIKIRICA-RATARI", "13311"  },
            { "SINJAC", "12416"  },
            { "SIRCA", "13220"  },
            { "SIVAC", "24204"  },
            { "SKENDEROVO", "24405"  },
            { "SKOBALJ", "13502"  },
            { "SKOPJE", "09820"  },
            { "SLAVONSKI BROD", "02632"  },
            { "SLOVAC", "15211"  },
            { "SMEDEREVO", "13670"  },
            { "SOCANICA", "12004"  },
            { "SOFIA", "09905"  },
            { "SOKOLOVICA", "14103"  },
            { "SOLTSZENTIMRE mh.", "16246"  },
            { "SOLTVADKERT", "16287"  },
            { "SOMBOR", "25550"  },
            { "SONTA", "25501"  },
            { "SOPOT KOSMAJSKI", "15406"  },
            { "SPITTAL-MILLSTATTERSEE", "02809"  },
            { "SRECKOVAC", "12425"  },
            { "SREMSKA MITROVICA", "16509"  },
            { "SREMSKI KARLOVCI", "16806"  },
            { "STALAC", "13352"  },
            { "STAMORA MORAVITA", "06113"  },
            { "STANDARD", "04255"  },
            { "STANICENJE", "12418"  },
            { "STAPARI", "15701"  },
            { "STARA PAZOVA", "16503"  },
            { "STARO SELO", "13402"  },
            { "STARO TRUBAREVO", "12503"  },
            { "STEPANOVICEVO", "23303"  },
            { "STEPOJEVAC", "15207"  },
            { "STITAR", "16301"  },
            { "STOPANJA", "12207"  },
            { "STRIZIVOJNA VRPOLJE", "02626"  },
            { "STRPCI", "15707"  },
            { "STUBAL", "11030"  },
            { "SUBOTICA", "23450"  },
            { "SUBOTICA PREDGRADE", "24409"  },
            { "SUKOVO", "12423"  },
            { "SUMARICE", "13219"  },
            { "SUPOVACKI MOST", "12514"  },
            { "SUSICA", "15702"  },
            { "SUSULAJKA", "14412"  },
            { "SUTOMORE", "31008"  },
            { "SUVA MORAVA", "11017"  },
            { "SVETOZAR MILETIC", "24401"  },
            { "SVRLJIG", "14007"  },
            { "SZABADSZALAS", "16220"  },
            { "TABAKOVAC", "14104"  },
            { "TABAKOVACKA REKA", "14105"  },
            { "TABANOVCI", "09352"  },
            { "TABDI mh.", "44958"  },
            { "TAMNIC", "14107"  },
            { "TATABANYA", "01131"  },
            { "TAVANKUT", "24406"  },
            { "TESICA", "12512"  },
            { "THESSALONIKI", "09860"  },
            { "TIMOK", "14022"  },
            { "TOMASEVAC", "22202"  },
            { "TOMICA BRDO", "13221"  },
            { "TOMINAC STA", "12216"  },
            { "TOMPA mh.", "16345"  },
            { "TOPCIDER", "16104"  },
            { "TOPLICA MILAN", "11128"  },
            { "TOPLICKA MALA PLANA", "11107"  },
            { "TOPLICKI BADNJEVAC", "11121"  },
            { "TOSIN BUNAR", "16012"  },
            { "TOVARNIK", "71001"  },
            { "TRBOVLJE", "02706"  },
            { "TRBUSANI", "13010"  },
            { "TRIPKOVA", "15717"  },
            { "TRNAVAC", "14101"  },
            { "TRNJANI", "12508"  },
            { "TRSTENIK", "12210"  },
            { "TRUPALE", "12516"  },
            { "TUBICI", "15109"  },
            { "ULJMA", "21007"  },
            { "USCE", "12106"  },
            { "UZDIN", "22201"  },
            { "UZICE", "15153"  },
            { "UZICE TERETNA", "15151"  },
            { "UZICI", "15110"  },
            { "VALAC", "12007"  },
            { "VALJEVO", "15251"  },
            { "VALJEVSKI GRADAC", "15101"  },
            { "VASILJEVAC STAJALISTE", "11120"  },
            { "VELES", "09832"  },
            { "VELIKA PLANA", "13401"  },
            { "VELIKA ZUPA", "15719"  },
            { "VELIKI BORAK", "15205"  },
            { "VELIKI JOVANOVAC", "12422"  },
            { "VELIKO ORASJE", "13507"  },
            { "VELJKOVO", "14111"  },
            { "VERUSIC", "23408"  },
            { "VILLACH HBF", "02802"  },
            { "VINKOVCI", "02620"  },
            { "VISOKA", "11122"  },
            { "VITANOVAC", "13218"  },
            { "VITKOVAC", "13216"  },
            { "VITKOVAC STAJ.", "12505"  },
            { "VLADICIN HAN", "11016"  },
            { "VLADIMIROVAC", "21003"  },
            { "VLAJKOVAC", "21008"  },
            { "VLAOLE", "14404"  },
            { "VLAOLE SELO", "14411"  },
            { "VLASKO POLJE", "15407"  },
            { "VOGANJ", "16508"  },
            { "VRANJE", "11021"  },
            { "VRANJSKA BANJA", "11020"  },
            { "VRANOVO", "13604"  },
            { "VRATARNICA", "14019"  },
            { "VRAZOGRNAC", "14301"  },
            { "VRBA STAJ", "12214"  },
            { "VRBAS", "23306"  },
            { "VRBNICA", "15715"  },
            { "VREOCI", "15250"  },
            { "VRNJACKA BANJA", "12211"  },
            { "VRSAC", "21009"  },
            { "VRTISTE", "12518"  },
            { "VUKOV SPOMENIK", "16054"  },
            { "WIEN HBF.", "02842"  },
            { "ZABLACE", "13006"  },
            { "ZAGRADE", "14303"  },
            { "ZAGREB GL.KOL.", "02654"  },
            { "ZAJECAR", "14060"  },
            { "ZAVOD", "13209"  },
            { "ZEDNIK", "23407"  },
            { "ZEMUN", "16002"  },
            { "ZEMUNSKO POLJE", "16001"  },
            { "ZIDANI MOST", "02704"  },
            { "ZITORADJA CENTAR", "11129"  },
            { "ZIVKOVO", "11007"  },
            { "ZLAKUSA", "15114"  },
            { "ZLATIBOR", "15704"  },
            { "ZMAJEVO", "23304"  },
            { "ZRENJANIN", "22550"  },
            { "ZRENJANIN FABRIKA", "22501"  },
            { "ZVECAN", "12008"  }
        };

        #endregion


        #region Train Type Strings

        const string train_FastTrainString = "FAST TRAIN";
        const string train_RegioVozString = "REGIO VOZ";
        const string train_InterCityString = "INTER CITY";

        #endregion


        #region Tarrife Type Strings

        const string tarr_FirstClassString = "First class";
        const string tarr_SecondClassString = "Second class";
        const string tarr_ObligatoryReservationString = "Obligatory reservation";
        const string tarr_BicycleString = "Bicikla";
        const string tarr_CousheteString = "Coushete";

        #endregion


        #region Public Methods

        /// <summary>
        /// Checks if time is sooner than other one. Format: (HH:mm).
        /// </summary>
        /// <returns>True if time is sooner, else False.</returns>
        public static bool IsTimeSooner(string time, string comparedToTime)
        {
            // Get values
            var values1 = time.Split(':');
            var values2 = comparedToTime.Split(':');

            double hour1 = int.Parse(values1[0]);
            double minutes1 = int.Parse(values1[1]);

            double hour2 = int.Parse(values2[0]);
            double minutes2 = int.Parse(values2[1]);

            // Compare values
            if (hour2 > hour1)
            {
                return true;
            }
            if (values1[0] == values2[0])
            {
                return minutes2 > minutes1;
            }

            return false;
        }

        /// <summary>
        /// Merges date from DateTime with string. Format = (HH:mm)
        /// </summary>
        /// <param name="nextDay">Should we increase day by one?</param>
        public static DateTime MergeDateWithStringTime(DateTime date, string departure, bool nextDay = false)
        {
            var hourAndMinutes = departure.Split(':');

            var result = new DateTime(
                date.Year,
                date.Month,
                date.Day,
                int.Parse(hourAndMinutes[0]),
                int.Parse(hourAndMinutes[1]),
                0);

            if (nextDay)
            {
                return result.AddDays(1);
            }

            return result;
        }

        /// <summary>
        /// Extracts time from string. Format = (HH:mm)
        /// </summary>
        public static TimeSpan ExtractTimeFromString(string value)
        {
            double minutes = 0;

            if (!String.IsNullOrWhiteSpace(value))
            {
                var hourAndMinutes = value.Split(':');

                if (hourAndMinutes[0] != "00")
                {
                    minutes += (double.Parse(hourAndMinutes[0]) * 60); // add hours
                }

                if (hourAndMinutes[1] != "00")
                {
                    minutes += double.Parse(hourAndMinutes[1]); // Add minutes
                }
            }

            return TimeSpan.FromMinutes(minutes);
        }

        /// <summary>
        /// Gets train type from string.
        /// </summary>
        public static TrainType GetTrainType(string value)
        {
            if (value == train_FastTrainString)
            {
                return TrainType.FastTrain;
            }
            if (value == train_RegioVozString)
            {
                return TrainType.RegioVoz;
            }
            if (value == train_InterCityString)
            {
                return TrainType.InterCity;
            }

            return TrainType.Local;
        }

        /// <summary>
        /// Gets tarrifes from list of strings. (Must be atlest one!)
        /// </summary>
        public static Tarrifes GetTarrifes(List<string> list)
        {
            // TODO: Make sure you have all possible tarrifes

            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("List must have atleast one element");
            }

            var output = ConvertStringToTarrife(list[0]);

            for (int i = 1; i < list.Count; i++) // i = 0 bacause We already added first element
            {
                output |= ConvertStringToTarrife(list[i]);
            }

            return output;
        }

        #endregion


        #region Internal Methods

        /// <summary>
        /// Converts string to tarrife.
        /// </summary>
        static Tarrifes ConvertStringToTarrife(string value)
        {
            // TODO: Make sure you have all possible tarrifes

            switch (value)
            {
                case tarr_BicycleString: return Tarrifes.Bicycle;
                case tarr_CousheteString: return Tarrifes.Coushete;
                case tarr_FirstClassString: return Tarrifes.FirstClass;
                case tarr_ObligatoryReservationString: return Tarrifes.ObligatoryReservation;
                case tarr_SecondClassString: return Tarrifes.SecondClass;
                default:
                    throw new ArgumentException("value must be one of predefined strings!");
            }
        }

        #endregion
    }
}
