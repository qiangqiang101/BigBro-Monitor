Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class WeatherInfo

    Public MorningWeather As String 'FGM
    Public AfternoonWeather As String 'FGA
    Public NightWeather As String 'FGN
    Public MinTemperature As Integer 'FMINT
    Public MaxTemperature As Integer 'FMAXT
    Public SignificantWeather As String 'FSIGW

    Public Sub New()
    End Sub

    Public Sub New(morning As String, afternoon As String, night As String, min As Integer, max As Integer, significant As String)
        MorningWeather = morning
        AfternoonWeather = afternoon
        NightWeather = night
        MinTemperature = min
        MaxTemperature = max
        SignificantWeather = significant
    End Sub

End Class

Public Module WeatherData

    Public DataTypeDic As New Dictionary(Of String, String) From {
        {"FSIGW", "FORECAST - GENERAL - DAILY SIGNIFICANT WEATHER"},
        {"FMINT", "FORECAST - GENERAL - DAILY MINIMUM TEMPERATURE"},
        {"FMAXT", "FORECAST - GENERAL - DAILY MAXIMUM TEMPERATURE"},
        {"FGN", "FORECAST - GENERAL - DAILY NIGHT"},
        {"FGA", "FORECAST - GENERAL - DAILY AFTERNOON"},
        {"FGM", "FORECAST - GENERAL - DAILY MORNING"},
        {"FMWH", "FORECAST - MARINE - WAVE HEIGHT"},
        {"FMWS", "FORECAST - MARINE - WIND SPEED"},
        {"FMWD", "FORECAST - MARINE - WIND DIRECTION"},
        {"FMSIGW", "FORECAST - MARINE - DAILY SIGNIFICANT WEATHER"},
        {"FMN", "FORECAST - MARINE - DAILY NIGHT"},
        {"FMA", "FORECAST - MARINE - DAILY AFTERNOON"},
        {"FMM", "FORECAST - MARINE - DAILY MORNING"},
        {"WINDSEA", "WARNING - STRONG WIND & ROUGH SEA"},
        {"RAIN", "WARNING - HEAVY RAIN"},
        {"CYCLONE", "WARNING - TROPICAL CYCLONE"},
        {"QUAKETSUNAMI", "ALERT - EARTHQUAKE/TSUNAMI"},
        {"SATHIMAWARI", "OBSERVATION - SATELLITE - HIMAWARI-8 ASEAN INFRA RED BAND"},
        {"RADARSABAHSARAWAK", "OBSERVATION - RADAR - SABAH & SARAWAK"},
        {"RADARPENINSULAMY", "OBSERVATION - RADAR - PENINSULA MALAYSIA"},
        {"RADARMY", "OBSERVATION - RADAR - MALAYSIA"},
        {"SATTERRAAQUA", "OBSERVATION - SATELLITE - TERRA/AQUA HOTSPOT PENINSULA"},
        {"SATNOAA", "OBSERVATION - SATELLITE - NOAA PENINSULA & SUMATERA"},
        {"SATFY2G", "OBSERVATION - SATELLITE - FENG YUN 2G ASEAN INFRA RED BAND"},
        {"WINDSEA2", "WARNING - STRONG WIND & ROUGH SEA"},
        {"RAIN2", "WARNING - HEAVY RAIN"},
        {"CYCLONE2", "WARNING - TROPICAL CYCLONE"},
        {"QUAKETSUNAMI2", "ALERT - EARTHQUAKE/TSUNAMI"},
        {"THUNDERSTORM2", "WARNING - THUNDERSTORM"},
        {"THUNDERSTORM", "WARNING - THUNDERSTORM"},
        {"RAINS180m", "OBSERVATION - RAINS - RAINS + 180m"},
        {"RAINS170m", "OBSERVATION - RAINS - RAINS + 170m"},
        {"RAINS160m", "OBSERVATION - RAINS - RAINS + 160m"},
        {"RAINS150m", "OBSERVATION - RAINS - RAINS + 150m"},
        {"RAINS140m", "OBSERVATION - RAINS - RAINS + 140m"},
        {"RAINS130m", "OBSERVATION - RAINS - RAINS + 130m"},
        {"RAINS120m", "OBSERVATION - RAINS - RAINS + 120m"},
        {"RAINS110m", "OBSERVATION - RAINS - RAINS + 110m"},
        {"RAINS100m", "OBSERVATION - RAINS - RAINS + 100m"},
        {"RAINS90m", "OBSERVATION - RAINS - RAINS + 90m"},
        {"RAINS80m", "OBSERVATION - RAINS - RAINS + 80m"},
        {"RAINS70m", "OBSERVATION - RAINS - RAINS + 70m"},
        {"RAINS60m", "OBSERVATION - RAINS - RAINS + 60m"},
        {"RAINS50m", "OBSERVATION - RAINS - RAINS + 50m"},
        {"RAINS40m", "OBSERVATION - RAINS - RAINS + 40m"},
        {"RAINS30m", "OBSERVATION - RAINS - RAINS + 30m"},
        {"RAINS20m", "OBSERVATION - RAINS - RAINS + 20m"},
        {"RAINS10m", "OBSERVATION - RAINS - RAINS + 10m"},
        {"RAINS", "OBSERVATION - RAINS - RAINS"},
        {"PRST_WX_ID", "OBSERVATION - HOURLY OBSERVATION - PRESENT WEATHER ID"},
        {"VIS", "OBSERVATION - HOURLY OBSERVATION - VISIBILITY"}}

    Public States As New Dictionary(Of String, String) From {
        {"LOCATION:1", "JOHOR"},
        {"LOCATION:2", "KEDAH"},
        {"LOCATION:3", "KELANTAN"},
        {"LOCATION:4", "KUALA LUMPUR"},
        {"LOCATION:5", "LABUAN"},
        {"LOCATION:6", "MELAKA"},
        {"LOCATION:7", "NEGERI SEMBILAN"},
        {"LOCATION:8", "PAHANG"},
        {"LOCATION:9", "PULAU PINANG"},
        {"LOCATION:10", "PERAK"},
        {"LOCATION:11", "PERLIS"},
        {"LOCATION:12", "PUTRAJAYA"},
        {"LOCATION:13", "SABAH"},
        {"LOCATION:14", "SARAWAK"},
        {"LOCATION:15", "SELANGOR"},
        {"LOCATION:16", "TERENGGANU"}}

    Public Districts As New List(Of District) From {
        New District("LOCATION:23", "MUAR", "LOCATION:1"),
        New District("LOCATION:22", "MERSING", "LOCATION:1"),
        New District("LOCATION:21", "LEDANG", "LOCATION:1"),
        New District("LOCATION:20", "KOTA TINGGI", "LOCATION:1"),
        New District("LOCATION:339", "KULAI", "LOCATION:1"),
        New District("LOCATION:18", "JOHOR BAHRU", "LOCATION:1"),
        New District("LOCATION:19", "KLUANG", "LOCATION:1"),
        New District("LOCATION:25", "SEGAMAT", "LOCATION:1"),
        New District("LOCATION:26", "PONTIAN", "LOCATION:1"),
        New District("LOCATION:17", "BATU PAHAT", "LOCATION:1"),
        New District("LOCATION:603", "TANGKAK", "LOCATION:1"),
        New District("LOCATION:33", "PADANG TERAP", "LOCATION:2"),
        New District("LOCATION:27", "BALING", "LOCATION:2"),
        New District("LOCATION:28", "KUALA MUDA", "LOCATION:2"),
        New District("LOCATION:29", "KUBANG PASU", "LOCATION:2"),
        New District("LOCATION:30", "KULIM", "LOCATION:2"),
        New District("LOCATION:31", "KOTA SETAR", "LOCATION:2"),
        New District("LOCATION:32", "LANGKAWI", "LOCATION:2"),
        New District("LOCATION:34", "PENDANG", "LOCATION:2"),
        New District("LOCATION:35", "POKOK SENA", "LOCATION:2"),
        New District("LOCATION:36", "SIK", "LOCATION:2"),
        New District("LOCATION:37", "YAN", "LOCATION:2"),
        New District("LOCATION:425", "BANDAR BAHARU", "LOCATION:2"),
        New District("LOCATION:40", "JELI", "LOCATION:3"),
        New District("LOCATION:41", "KOTA BHARU", "LOCATION:3"),
        New District("LOCATION:42", "KUALA KRAI", "LOCATION:3"),
        New District("LOCATION:38", "BACHOK", "LOCATION:3"),
        New District("LOCATION:44", "MACHANG", "LOCATION:3"),
        New District("LOCATION:46", "PASIR PUTEH", "LOCATION:3"),
        New District("LOCATION:47", "TANAH MERAH", "LOCATION:3"),
        New District("LOCATION:48", "TUMPAT", "LOCATION:3"),
        New District("LOCATION:45", "PASIR MAS", "LOCATION:3"),
        New District("LOCATION:39", "GUA MUSANG", "LOCATION:3"),
        New District("LOCATION:49", "KUALA LUMPUR", "LOCATION:4"),
        New District("LOCATION:171", "LABUAN", "LOCATION:5"),
        New District("LOCATION:669", "FP LABUAN", "LOCATION:5"),
        New District("LOCATION:602", "CENTRAL MALACCA", "LOCATION:6"),
        New District("LOCATION:51", "ALOR GAJAH", "LOCATION:6"),
        New District("LOCATION:660", "CENTRAL MELAKA", "LOCATION:6"),
        New District("LOCATION:52", "JASIN", "LOCATION:6"),
        New District("LOCATION:53", "MELAKA TENGAH", "LOCATION:6"),
        New District("LOCATION:60", "TAMPIN", "LOCATION:7"),
        New District("LOCATION:55", "JEMPOL", "LOCATION:7"),
        New District("LOCATION:56", "KUALA PILAH", "LOCATION:7"),
        New District("LOCATION:57", "PORT DICKSON", "LOCATION:7"),
        New District("LOCATION:58", "REMBAU", "LOCATION:7"),
        New District("LOCATION:59", "SEREMBAN", "LOCATION:7"),
        New District("LOCATION:54", "JELEBU", "LOCATION:7"),
        New District("LOCATION:66", "LIPIS", "LOCATION:8"),
        New District("LOCATION:68", "PEKAN", "LOCATION:8"),
        New District("LOCATION:69", "RAUB", "LOCATION:8"),
        New District("LOCATION:70", "ROMPIN", "LOCATION:8"),
        New District("LOCATION:71", "TEMERLOH", "LOCATION:8"),
        New District("LOCATION:65", "KUANTAN", "LOCATION:8"),
        New District("LOCATION:64", "JERANTUT", "LOCATION:8"),
        New District("LOCATION:63", "CAMERON HIGHLANDS", "LOCATION:8"),
        New District("LOCATION:62", "BERA", "LOCATION:8"),
        New District("LOCATION:61", "BENTONG", "LOCATION:8"),
        New District("LOCATION:67", "MARAN", "LOCATION:8"),
        New District("LOCATION:342", "BARAT DAYA", "LOCATION:9"),
        New District("LOCATION:600", "CENTRAL SEBERANG PERAI", "LOCATION:9"),
        New District("LOCATION:597", "SOUTHWEST PENANG ISLAND", "LOCATION:9"),
        New District("LOCATION:598", "NORTHEAST PENANG ISLAND", "LOCATION:9"),
        New District("LOCATION:72", "SEBERANG PRAI SELATAN", "LOCATION:9"),
        New District("LOCATION:73", "SEBERANG PRAI TENGAH", "LOCATION:9"),
        New District("LOCATION:74", "SEBERANG PRAI UTARA", "LOCATION:9"),
        New District("LOCATION:75", "TIMUR LAUT", "LOCATION:9"),
        New District("LOCATION:599", "NORTH SEBERANG PERAI", "LOCATION:9"),
        New District("LOCATION:601", "SOUTH SEBERANG PERAI", "LOCATION:9"),
        New District("LOCATION:83", "MANJUNG", "LOCATION:10"),
        New District("LOCATION:76", "BATANG PADANG", "LOCATION:10"),
        New District("LOCATION:77", "HILIR PERAK", "LOCATION:10"),
        New District("LOCATION:78", "HULU PERAK", "LOCATION:10"),
        New District("LOCATION:79", "KERIAN", "LOCATION:10"),
        New District("LOCATION:80", "KINTA", "LOCATION:10"),
        New District("LOCATION:81", "KUALA KANGSAR", "LOCATION:10"),
        New District("LOCATION:84", "PERAK TENGAH", "LOCATION:10"),
        New District("LOCATION:341", "LARUT, MATANG & SELAMA", "LOCATION:10"),
        New District("LOCATION:433", "BAGAN DATUK", "LOCATION:10"),
        New District("LOCATION:432", "KAMPAR", "LOCATION:10"),
        New District("LOCATION:435", "MUALLIM", "LOCATION:10"),
        New District("LOCATION:411", "PERLIS", "LOCATION:11"),
        New District("LOCATION:89", "PUTRAJAYA", "LOCATION:12"),
        New District("LOCATION:241", "KOTA KINABALU", "LOCATION:13"),
        New District("LOCATION:247", "LAHAD DATU", "LOCATION:13"),
        New District("LOCATION:238", "BEAUFORT", "LOCATION:13"),
        New District("LOCATION:343", "NABAWAN", "LOCATION:13"),
        New District("LOCATION:246", "KUDAT", "LOCATION:13"),
        New District("LOCATION:245", "KENINGAU", "LOCATION:13"),
        New District("LOCATION:252", "SANDAKAN", "LOCATION:13"),
        New District("LOCATION:255", "SIPITANG", "LOCATION:13"),
        New District("LOCATION:256", "TAMBUNAN", "LOCATION:13"),
        New District("LOCATION:254", "SEMPORNA", "LOCATION:13"),
        New District("LOCATION:240", "KOTA BELUD", "LOCATION:13"),
        New District("LOCATION:258", "TENOM", "LOCATION:13"),
        New District("LOCATION:447", "PUTATAN", "LOCATION:13"),
        New District("LOCATION:452", "KUNAK", "LOCATION:13"),
        New District("LOCATION:251", "RANAU", "LOCATION:13"),
        New District("LOCATION:257", "TAWAU", "LOCATION:13"),
        New District("LOCATION:455", "TELUPID", "LOCATION:13"),
        New District("LOCATION:250", "TUARAN", "LOCATION:13"),
        New District("LOCATION:244", "KUALA PENYU", "LOCATION:13"),
        New District("LOCATION:457", "PITAS", "LOCATION:13"),
        New District("LOCATION:249", "PENAMPANG", "LOCATION:13"),
        New District("LOCATION:243", "KOTA MARUDU", "LOCATION:13"),
        New District("LOCATION:454", "TONGOD", "LOCATION:13"),
        New District("LOCATION:242", "KINABATANGAN", "LOCATION:13"),
        New District("LOCATION:239", "BELURAN", "LOCATION:13"),
        New District("LOCATION:248", "PAPAR", "LOCATION:13"),
        New District("LOCATION:589", "TELANG USAN", "LOCATION:14"),
        New District("LOCATION:591", "MARUDI", "LOCATION:14"),
        New District("LOCATION:270", "LUNDU", "LOCATION:14"),
        New District("LOCATION:594", "LAWAS", "LOCATION:14"),
        New District("LOCATION:484", "BELURU", "LOCATION:14"),
        New District("LOCATION:580", "BUKIT MABONG", "LOCATION:14"),
        New District("LOCATION:561", "KABONG", "LOCATION:14"),
        New District("LOCATION:569", "KANOWIT", "LOCATION:14"),
        New District("LOCATION:585", "SEBAUH", "LOCATION:14"),
        New District("LOCATION:553", "SIMUNJAN", "LOCATION:14"),
        New District("LOCATION:572", "TANJUNG MANIS", "LOCATION:14"),
        New District("LOCATION:557", "BETONG", "LOCATION:14"),
        New District("LOCATION:592", "LIMBANG", "LOCATION:14"),
        New District("LOCATION:552", "SAMARAHAN", "LOCATION:14"),
        New District("LOCATION:554", "SRI AMAN", "LOCATION:14"),
        New District("LOCATION:556", "LUBOK ANTU", "LOCATION:14"),
        New District("LOCATION:259", "BELAGA", "LOCATION:14"),
        New District("LOCATION:558", "PUSA", "LOCATION:14"),
        New District("LOCATION:560", "SARATOK", "LOCATION:14"),
        New District("LOCATION:562", "SARIKEI", "LOCATION:14"),
        New District("LOCATION:563", "PAKAN", "LOCATION:14"),
        New District("LOCATION:458", "BAU", "LOCATION:14"),
        New District("LOCATION:549", "TEBEDU", "LOCATION:14"),
        New District("LOCATION:463", "ASAJAYA", "LOCATION:14"),
        New District("LOCATION:565", "JULAU", "LOCATION:14"),
        New District("LOCATION:566", "MERADONG", "LOCATION:14"),
        New District("LOCATION:567", "SIBU", "LOCATION:14"),
        New District("LOCATION:548", "SERIAN", "LOCATION:14"),
        New District("LOCATION:570", "SELANGAU", "LOCATION:14"),
        New District("LOCATION:545", "KUCHING", "LOCATION:14"),
        New District("LOCATION:571", "MUKAH", "LOCATION:14"),
        New District("LOCATION:573", "DARO", "LOCATION:14"),
        New District("LOCATION:574", "MATU", "LOCATION:14"),
        New District("LOCATION:575", "DALAT", "LOCATION:14"),
        New District("LOCATION:577", "KAPIT", "LOCATION:14"),
        New District("LOCATION:578", "SONG", "LOCATION:14"),
        New District("LOCATION:582", "BINTULU", "LOCATION:14"),
        New District("LOCATION:583", "TATAU", "LOCATION:14"),
        New District("LOCATION:586", "MIRI", "LOCATION:14"),
        New District("LOCATION:587", "SUBIS", "LOCATION:14"),
        New District("LOCATION:114", "SEPANG", "LOCATION:15"),
        New District("LOCATION:109", "KLANG", "LOCATION:15"),
        New District("LOCATION:658", "KELANG", "LOCATION:15"),
        New District("LOCATION:106", "GOMBAK", "LOCATION:15"),
        New District("LOCATION:107", "HULU LANGAT", "LOCATION:15"),
        New District("LOCATION:108", "HULU SELANGOR", "LOCATION:15"),
        New District("LOCATION:110", "KUALA LANGAT", "LOCATION:15"),
        New District("LOCATION:111", "KUALA SELANGOR", "LOCATION:15"),
        New District("LOCATION:112", "PETALING", "LOCATION:15"),
        New District("LOCATION:113", "SABAK BERNAM", "LOCATION:15"),
        New District("LOCATION:118", "KEMAMAN", "LOCATION:16"),
        New District("LOCATION:436", "KUALA NERUS", "LOCATION:16"),
        New District("LOCATION:121", "SETIU", "LOCATION:16"),
        New District("LOCATION:120", "MARANG", "LOCATION:16"),
        New District("LOCATION:115", "BESUT", "LOCATION:16"),
        New District("LOCATION:116", "DUNGUN", "LOCATION:16"),
        New District("LOCATION:117", "HULU TERENGGANU", "LOCATION:16"),
        New District("LOCATION:119", "KUALA TERENGGANU", "LOCATION:16")}

    Public Towns As New List(Of Town) From {
        New Town("LOCATION:132", "NUSAJAYA", "LOCATION:1"),
        New Town("LOCATION:439", "KULAI", "LOCATION:1"),
        New Town("LOCATION:659", "ISKANDAR PUTERI", "LOCATION:1"),
        New Town("LOCATION:133", "PASIR GUDANG", "LOCATION:1"),
        New Town("LOCATION:134", "PONTIAN", "LOCATION:1"),
        New Town("LOCATION:135", "SEGAMAT", "LOCATION:1"),
        New Town("LOCATION:136", "SENAI", "LOCATION:1"),
        New Town("LOCATION:137", "SIMPANG RENGGAM", "LOCATION:1"),
        New Town("LOCATION:138", "YONG PENG", "LOCATION:1"),
        New Town("LOCATION:122", "AYER HITAM", "LOCATION:1"),
        New Town("LOCATION:123", "BATU PAHAT", "LOCATION:1"),
        New Town("LOCATION:124", "JOHOR BAHRU", "LOCATION:1"),
        New Town("LOCATION:125", "LABIS", "LOCATION:1"),
        New Town("LOCATION:126", "TANGKAK", "LOCATION:1"),
        New Town("LOCATION:127", "MUAR", "LOCATION:1"),
        New Town("LOCATION:128", "PAGOH", "LOCATION:1"),
        New Town("LOCATION:129", "KLUANG", "LOCATION:1"),
        New Town("LOCATION:130", "KOTA TINGGI", "LOCATION:1"),
        New Town("LOCATION:131", "MERSING", "LOCATION:1"),
        New Town("LOCATION:141", "JITRA", "LOCATION:2"),
        New Town("LOCATION:142", "KUALA NERANG", "LOCATION:2"),
        New Town("LOCATION:143", "KULIM", "LOCATION:2"),
        New Town("LOCATION:144", "LANGKAWI", "LOCATION:2"),
        New Town("LOCATION:145", "PENDANG", "LOCATION:2"),
        New Town("LOCATION:146", "POKOK SENA", "LOCATION:2"),
        New Town("LOCATION:147", "SIK", "LOCATION:2"),
        New Town("LOCATION:148", "SUNGAI PETANI", "LOCATION:2"),
        New Town("LOCATION:149", "YAN", "LOCATION:2"),
        New Town("LOCATION:426", "SERDANG", "LOCATION:2"),
        New Town("LOCATION:410", "KUBANG PASU", "LOCATION:2"),
        New Town("LOCATION:408", "KUALA MUDA", "LOCATION:2"),
        New Town("LOCATION:139", "ALOR STAR", "LOCATION:2"),
        New Town("LOCATION:140", "BALING", "LOCATION:2"),
        New Town("LOCATION:155", "LOJING", "LOCATION:3"),
        New Town("LOCATION:156", "MACHANG", "LOCATION:3"),
        New Town("LOCATION:158", "PASIR PUTEH", "LOCATION:3"),
        New Town("LOCATION:160", "TANAH MERAH", "LOCATION:3"),
        New Town("LOCATION:161", "TUMPAT", "LOCATION:3"),
        New Town("LOCATION:157", "PASIR MAS", "LOCATION:3"),
        New Town("LOCATION:159", "RANTAU PANJANG", "LOCATION:3"),
        New Town("LOCATION:150", "BACHOK", "LOCATION:3"),
        New Town("LOCATION:151", "GUA MUSANG", "LOCATION:3"),
        New Town("LOCATION:152", "JELI", "LOCATION:3"),
        New Town("LOCATION:153", "KOTA BHARU", "LOCATION:3"),
        New Town("LOCATION:154", "KUALA KRAI", "LOCATION:3"),
        New Town("LOCATION:168", "SELAYANG", "LOCATION:4"),
        New Town("LOCATION:170", "SUNGAI BESI", "LOCATION:4"),
        New Town("LOCATION:340", "KUALA LUMPUR", "LOCATION:4"),
        New Town("LOCATION:162", "AMPANG", "LOCATION:4"),
        New Town("LOCATION:163", "BANGSAR", "LOCATION:4"),
        New Town("LOCATION:164", "BUKIT BINTANG", "LOCATION:4"),
        New Town("LOCATION:165", "CHERAS", "LOCATION:4"),
        New Town("LOCATION:166", "JALAN DUTA", "LOCATION:4"),
        New Town("LOCATION:167", "KEPONG", "LOCATION:4"),
        New Town("LOCATION:169", "SETAPAK", "LOCATION:4"),
        New Town("LOCATION:628", "LABUAN", "LOCATION:5"),
        New Town("LOCATION:172", "ALOR GAJAH", "LOCATION:6"),
        New Town("LOCATION:661", "MELAKA CITY", "LOCATION:6"),
        New Town("LOCATION:179", "TANGGA BATU", "LOCATION:6"),
        New Town("LOCATION:176", "JASIN", "LOCATION:6"),
        New Town("LOCATION:177", "MASJID TANAH", "LOCATION:6"),
        New Town("LOCATION:174", "BANDARAYA MELAKA", "LOCATION:6"),
        New Town("LOCATION:175", "DURIAN TUNGGAL", "LOCATION:6"),
        New Town("LOCATION:173", "AYER KEROH", "LOCATION:6"),
        New Town("LOCATION:178", "MERLIMAU", "LOCATION:6"),
        New Town("LOCATION:680", "PDSA ENSTEK", "LOCATION:7"),
        New Town("LOCATION:180", "GEMAS", "LOCATION:7"),
        New Town("LOCATION:181", "JELEBU", "LOCATION:7"),
        New Town("LOCATION:182", "JEMPOL", "LOCATION:7"),
        New Town("LOCATION:183", "KUALA KLAWANG", "LOCATION:7"),
        New Town("LOCATION:184", "KUALA PILAH", "LOCATION:7"),
        New Town("LOCATION:185", "NILAI", "LOCATION:7"),
        New Town("LOCATION:186", "PORT DICKSON", "LOCATION:7"),
        New Town("LOCATION:187", "REMBAU", "LOCATION:7"),
        New Town("LOCATION:188", "SEREMBAN", "LOCATION:7"),
        New Town("LOCATION:189", "TAMPIN", "LOCATION:7"),
        New Town("LOCATION:539", "MALACCA CITY", "LOCATION:7"),
        New Town("LOCATION:190", "BENTONG", "LOCATION:8"),
        New Town("LOCATION:675", "BATU EMBUN", "LOCATION:8"),
        New Town("LOCATION:193", "KUANTAN", "LOCATION:8"),
        New Town("LOCATION:200", "RAUB", "LOCATION:8"),
        New Town("LOCATION:199", "PEKAN", "LOCATION:8"),
        New Town("LOCATION:202", "TRIANG", "LOCATION:8"),
        New Town("LOCATION:192", "JERANTUT", "LOCATION:8"),
        New Town("LOCATION:201", "TEMERLOH", "LOCATION:8"),
        New Town("LOCATION:198", "MUADZAM SHAH", "LOCATION:8"),
        New Town("LOCATION:194", "KUALA LIPIS", "LOCATION:8"),
        New Town("LOCATION:195", "KUALA ROMPIN", "LOCATION:8"),
        New Town("LOCATION:196", "MARAN", "LOCATION:8"),
        New Town("LOCATION:197", "MENTAKAB", "LOCATION:8"),
        New Town("LOCATION:191", "BERA", "LOCATION:8"),
        New Town("LOCATION:205", "BAYAN LEPAS", "LOCATION:9"),
        New Town("LOCATION:677", "PRAI", "LOCATION:9"),
        New Town("LOCATION:203", "AYER ITAM", "LOCATION:9"),
        New Town("LOCATION:204", "BALIK PULAU", "LOCATION:9"),
        New Town("LOCATION:407", "BARAT DAYA", "LOCATION:9"),
        New Town("LOCATION:206", "BATU KAWAN", "LOCATION:9"),
        New Town("LOCATION:207", "BUTTERWORTH", "LOCATION:9"),
        New Town("LOCATION:208", "BUKIT MERTAJAM", "LOCATION:9"),
        New Town("LOCATION:209", "BUKIT TENGAH", "LOCATION:9"),
        New Town("LOCATION:210", "GEORGETOWN", "LOCATION:9"),
        New Town("LOCATION:211", "KEPALA BATAS", "LOCATION:9"),
        New Town("LOCATION:212", "NIBONG TEBAL", "LOCATION:9"),
        New Town("LOCATION:213", "PERAI", "LOCATION:9"),
        New Town("LOCATION:231", "SLIM RIVER", "LOCATION:10"),
        New Town("LOCATION:431", "SERI ISKANDAR", "LOCATION:10"),
        New Town("LOCATION:401", "PERAK TENGAH", "LOCATION:10"),
        New Town("LOCATION:398", "KERIAN", "LOCATION:10"),
        New Town("LOCATION:383", "HILIR PERAK", "LOCATION:10"),
        New Town("LOCATION:215", "BAGAN SERAI", "LOCATION:10"),
        New Town("LOCATION:216", "BATU GAJAH", "LOCATION:10"),
        New Town("LOCATION:217", "GERIK", "LOCATION:10"),
        New Town("LOCATION:218", "GOPENG", "LOCATION:10"),
        New Town("LOCATION:219", "IPOH", "LOCATION:10"),
        New Town("LOCATION:220", "KAMPAR", "LOCATION:10"),
        New Town("LOCATION:221", "KUALA KANGSAR", "LOCATION:10"),
        New Town("LOCATION:222", "LENGGONG", "LOCATION:10"),
        New Town("LOCATION:223", "PARIT BUNTAR", "LOCATION:10"),
        New Town("LOCATION:224", "SELAMA", "LOCATION:10"),
        New Town("LOCATION:225", "SUNGAI SIPUT", "LOCATION:10"),
        New Town("LOCATION:226", "SITIAWAN", "LOCATION:10"),
        New Town("LOCATION:227", "TAIPING", "LOCATION:10"),
        New Town("LOCATION:228", "TAPAH", "LOCATION:10"),
        New Town("LOCATION:229", "TANJUNG MALIM", "LOCATION:10"),
        New Town("LOCATION:230", "TELUK INTAN", "LOCATION:10"),
        New Town("LOCATION:434", "BAGAN DATUK", "LOCATION:10"),
        New Town("LOCATION:676", "LUBOK MERBAU", "LOCATION:10"),
        New Town("LOCATION:214", "BAGAN DATOH", "LOCATION:10"),
        New Town("LOCATION:679", "KUALA PERLIS", "LOCATION:11"),
        New Town("LOCATION:412", "PADANG BESAR UTARA", "LOCATION:11"),
        New Town("LOCATION:234", "CHUPING", "LOCATION:11"),
        New Town("LOCATION:424", "PERLIS", "LOCATION:11"),
        New Town("LOCATION:232", "ARAU", "LOCATION:11"),
        New Town("LOCATION:236", "PADANG BESAR", "LOCATION:11"),
        New Town("LOCATION:671", "KANGAR", "LOCATION:11"),
        New Town("LOCATION:233", "BESERI", "LOCATION:11"),
        New Town("LOCATION:674", "KASA", "LOCATION:12"),
        New Town("LOCATION:237", "PUTRAJAYA", "LOCATION:12"),
        New Town("LOCATION:627", "NABAWAN", "LOCATION:13"),
        New Town("LOCATION:607", "KOTA KINABALU", "LOCATION:13"),
        New Town("LOCATION:608", "TAWAU", "LOCATION:13"),
        New Town("LOCATION:609", "KUDAT", "LOCATION:13"),
        New Town("LOCATION:610", "SEMPORNA", "LOCATION:13"),
        New Town("LOCATION:611", "TENOM", "LOCATION:13"),
        New Town("LOCATION:612", "PAPAR", "LOCATION:13"),
        New Town("LOCATION:613", "BELURAN", "LOCATION:13"),
        New Town("LOCATION:614", "TAMBUNAN", "LOCATION:13"),
        New Town("LOCATION:615", "KOTA BELUD", "LOCATION:13"),
        New Town("LOCATION:616", "KINABATANGAN", "LOCATION:13"),
        New Town("LOCATION:617", "TELUPID", "LOCATION:13"),
        New Town("LOCATION:618", "TONGOD", "LOCATION:13"),
        New Town("LOCATION:619", "PUTATAN", "LOCATION:13"),
        New Town("LOCATION:620", "TUARAN", "LOCATION:13"),
        New Town("LOCATION:621", "KOTA MARUDU", "LOCATION:13"),
        New Town("LOCATION:622", "PENAMPANG", "LOCATION:13"),
        New Town("LOCATION:623", "SIPITANG", "LOCATION:13"),
        New Town("LOCATION:624", "PITAS", "LOCATION:13"),
        New Town("LOCATION:625", "RANAU", "LOCATION:13"),
        New Town("LOCATION:626", "KUNAK", "LOCATION:13"),
        New Town("LOCATION:606", "SANDAKAN", "LOCATION:13"),
        New Town("LOCATION:629", "KENINGAU", "LOCATION:13"),
        New Town("LOCATION:630", "KUALA PENYU", "LOCATION:13"),
        New Town("LOCATION:631", "LAHAD DATU", "LOCATION:13"),
        New Town("LOCATION:632", "BEAUFORT", "LOCATION:13"),
        New Town("LOCATION:260", "BETONG", "LOCATION:14"),
        New Town("LOCATION:269", "LUBOK ANTU", "LOCATION:14"),
        New Town("LOCATION:633", "LUNDU", "LOCATION:14"),
        New Town("LOCATION:634", "TEBEDU", "LOCATION:14"),
        New Town("LOCATION:635", "BELAGA", "LOCATION:14"),
        New Town("LOCATION:636", "PUSA", "LOCATION:14"),
        New Town("LOCATION:637", "PAKAN", "LOCATION:14"),
        New Town("LOCATION:638", "BAU", "LOCATION:14"),
        New Town("LOCATION:639", "ASAJAYA", "LOCATION:14"),
        New Town("LOCATION:640", "JULAU", "LOCATION:14"),
        New Town("LOCATION:641", "SELANGAU", "LOCATION:14"),
        New Town("LOCATION:266", "KUCHING", "LOCATION:14"),
        New Town("LOCATION:649", "KABONG", "LOCATION:14"),
        New Town("LOCATION:648", "BUKIT MABONG", "LOCATION:14"),
        New Town("LOCATION:647", "BELURU", "LOCATION:14"),
        New Town("LOCATION:645", "SONG", "LOCATION:14"),
        New Town("LOCATION:644", "DALAT", "LOCATION:14"),
        New Town("LOCATION:279", "SERIAN", "LOCATION:14"),
        New Town("LOCATION:281", "SRI AMAN", "LOCATION:14"),
        New Town("LOCATION:280", "SIBU", "LOCATION:14"),
        New Town("LOCATION:277", "SARATOK", "LOCATION:14"),
        New Town("LOCATION:278", "SARIKEI", "LOCATION:14"),
        New Town("LOCATION:276", "SANTUBONG", "LOCATION:14"),
        New Town("LOCATION:651", "SIMUNJAN", "LOCATION:14"),
        New Town("LOCATION:275", "MULU", "LOCATION:14"),
        New Town("LOCATION:274", "MUKAH", "LOCATION:14"),
        New Town("LOCATION:643", "MATU", "LOCATION:14"),
        New Town("LOCATION:672", "TAMAN NEGARA GUNUNG MULU", "LOCATION:14"),
        New Town("LOCATION:273", "MIRI", "LOCATION:14"),
        New Town("LOCATION:652", "TANJUNG MANIS", "LOCATION:14"),
        New Town("LOCATION:653", "LONG LAMA", "LOCATION:14"),
        New Town("LOCATION:673", "TAMAN NEGARA NIAH", "LOCATION:14"),
        New Town("LOCATION:267", "LIMBANG", "LOCATION:14"),
        New Town("LOCATION:265", "KOTA SAMARAHAN", "LOCATION:14"),
        New Town("LOCATION:272", "MATU DARO", "LOCATION:14"),
        New Town("LOCATION:268", "LAWAS", "LOCATION:14"),
        New Town("LOCATION:263", "KANOWIT", "LOCATION:14"),
        New Town("LOCATION:282", "TATAU", "LOCATION:14"),
        New Town("LOCATION:264", "KAPIT", "LOCATION:14"),
        New Town("LOCATION:650", "SEBAUH", "LOCATION:14"),
        New Town("LOCATION:262", "BINTULU", "LOCATION:14"),
        New Town("LOCATION:642", "DARO", "LOCATION:14"),
        New Town("LOCATION:261", "BINTAGOR", "LOCATION:14"),
        New Town("LOCATION:300", "SUBANG JAYA", "LOCATION:15"),
        New Town("LOCATION:288", "KAJANG", "LOCATION:15"),
        New Town("LOCATION:382", "HULU LANGAT", "LOCATION:15"),
        New Town("LOCATION:287", "DAMANSARA", "LOCATION:15"),
        New Town("LOCATION:286", "CYBERJAYA", "LOCATION:15"),
        New Town("LOCATION:285", "BATU CAVES", "LOCATION:15"),
        New Town("LOCATION:404", "HULU SELANGOR", "LOCATION:15"),
        New Town("LOCATION:284", "BANTING", "LOCATION:15"),
        New Town("LOCATION:283", "BANGI", "LOCATION:15"),
        New Town("LOCATION:537", "PELABUHAN KLANG", "LOCATION:15"),
        New Town("LOCATION:605", "PORT KLANG", "LOCATION:15"),
        New Town("LOCATION:289", "KUALA KUBU BHARU", "LOCATION:15"),
        New Town("LOCATION:290", "KUALA SELANGOR", "LOCATION:15"),
        New Town("LOCATION:291", "RAWANG", "LOCATION:15"),
        New Town("LOCATION:293", "PETALING JAYA", "LOCATION:15"),
        New Town("LOCATION:294", "SABAK BERNAM", "LOCATION:15"),
        New Town("LOCATION:295", "SHAH ALAM", "LOCATION:15"),
        New Town("LOCATION:296", "SEMENYIH", "LOCATION:15"),
        New Town("LOCATION:297", "SENTUL", "LOCATION:15"),
        New Town("LOCATION:298", "SEPANG", "LOCATION:15"),
        New Town("LOCATION:299", "SERI KEMBANGAN", "LOCATION:15"),
        New Town("LOCATION:302", "BESUT", "LOCATION:16"),
        New Town("LOCATION:678", "KERTEH", "LOCATION:16"),
        New Town("LOCATION:437", "KUALA NERUS", "LOCATION:16"),
        New Town("LOCATION:309", "SETIU", "LOCATION:16"),
        New Town("LOCATION:308", "PAKA", "LOCATION:16"),
        New Town("LOCATION:307", "KUALA TERENGGANU", "LOCATION:16"),
        New Town("LOCATION:306", "KERTIH", "LOCATION:16"),
        New Town("LOCATION:305", "KEMAMAN", "LOCATION:16"),
        New Town("LOCATION:304", "JERTEH", "LOCATION:16"),
        New Town("LOCATION:303", "DUNGUN", "LOCATION:16"),
        New Town("LOCATION:301", "BANDAR PERMAISURI", "LOCATION:16")}

    Public Function GetStateID(stateName As String) As String
        Dim keys = (From entry In States Where entry.Value = stateName
                    Select entry.Key).FirstOrDefault
        Return keys
    End Function

    Public Function GetDistricts(stateid As String) As List(Of District)
        Return Districts.Where(Function(x) x.RootID = stateid).ToList
    End Function

    Public Function GetTowns(stateid As String) As List(Of Town)
        Return Towns.Where(Function(x) x.RootID = stateid).ToList
    End Function

    Public Function GetGreetings() As String
        Dim dt = Now
        If dt.Hour < 12 Then
            Return "Morning"
        Else
            If dt.Hour < 18 Then
                Return "Afternoon"
            Else
                Return "Night"
            End If
        End If
    End Function

    Public Function Weather(locationID As String, Optional startDate As Date = Nothing, Optional endDate As Date = Nothing, Optional malayLang As Boolean = False, Optional timeout As Integer = 5000, Optional retryTimes As Integer = 0) As WeatherInfo
        If startDate = Nothing Then startDate = Now
        If endDate = Nothing Then endDate = Now
        Dim startDateStr As String = startDate.ToString("yyyy-MM-dd")
        Dim endDateStr As String = endDate.ToString("yyyy-MM-dd")
        Dim query As String = "https://api.met.gov.my/v2.1/data?datasetid=FORECAST&datacategoryid=GENERAL&locationid=" & locationID & "&start_date=" & startDateStr & "&end_date=" & endDateStr
        If malayLang Then query &= "&lang=ms"

        If retryTimes > 5 Then
            Logger.Log("Unable to get API data from Malaysian Meteorological Department Server after 5 attempts.")
            Return New WeatherInfo("N/A", "N/A", "N/A", 0, 0, "N/A")
        Else
            Try
                Dim req As HttpWebRequest = WebRequest.Create(query)
                With req
                    .Timeout = timeout
                    .Credentials = CredentialCache.DefaultCredentials
                    .Accept = "*/*"
                    .Method = "GET"
                    .Host = "api.met.gov.my"
                    .ContentType = "application/json"
                    .Headers.Add("Authorization", "METToken 84d06ae6c0565f9e0e8db00522b4ad4b6d51bef1")
                End With
                Dim res As HttpWebResponse = req.GetResponse()
                Dim reader As New StreamReader(res.GetResponseStream)
                Dim json As String = reader.ReadToEnd
                Dim obj As JObject = JObject.Parse(json)

                Dim morning As String = Nothing
                Dim afternoon As String = Nothing
                Dim night As String = Nothing
                Dim minTemp As Integer = 0
                Dim maxTemp As Integer = 0
                Dim significant As String = Nothing

                If obj("results").Count = 0 Then
                    morning = "N/A"
                    afternoon = "N/A"
                    night = "N/A"
                    minTemp = 0
                    maxTemp = 0
                    significant = "N/A"
                Else
                    For Each result In obj("results")
                        Select Case CStr(result("datatype"))
                            Case "FGM"
                                morning = CStr(result("value"))
                            Case "FGA"
                                afternoon = CStr(result("value"))
                            Case "FGN"
                                night = CStr(result("value"))
                            Case "FMINT"
                                minTemp = CInt(result("value"))
                            Case "FMAXT"
                                maxTemp = CInt(result("value"))
                            Case "FSIGW"
                                significant = CStr(result("value"))
                        End Select
                    Next
                End If

                Return New WeatherInfo(morning, afternoon, night, minTemp, maxTemp, significant)
            Catch ex As Exception
                Return Weather(locationID, startDate, endDate, malayLang, timeout, retryTimes + 1)
            End Try
        End If
    End Function

End Module

Public Class District

    Public ID As String
    Public Name As String
    Public RootID As String

    Public Sub New(id As String, name As String, root As String)
        Me.ID = id
        Me.Name = name
        Me.RootID = root
    End Sub

End Class

Public Class Town

    Public ID As String
    Public Name As String
    Public RootID As String

    Public Sub New(id As String, name As String, root As String)
        Me.ID = id
        Me.Name = name
        Me.RootID = root
    End Sub

End Class