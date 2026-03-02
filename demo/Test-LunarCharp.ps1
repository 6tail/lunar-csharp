
param (
    [string]$Date = (Get-Date).ToString("yyyy-MM-dd")
)
function FindLunarDllPath {
    $lunarDllPath = ''
    Get-ChildItem -Path "lunar.dll" -Recurse -ErrorAction SilentlyContinue | ForEach-Object {
        $lunarDllPath = $_.FullName
    }
    return $lunarDllPath
}
$lunarDllPath = FindLunarDllPath
if (!$lunarDllPath) {
    & dotnet build 
    $lunarDllPath = FindLunarDllPath
    if (!$lunarDllPath) {
        Write-Host "找不到 lunar.dll，請確保已編譯專案。" -ForegroundColor Red
        exit 1
    }
}
Add-Type -Path $lunarDllPath
$solar = [Lunar.Solar]::new([DateTime]::Parse($Date))
Write-Host "Solar: $($solar.FullString)"
$lunar = $solar.Lunar
Write-Host "Lunar: $($lunar.FullString)"

# 以表格方式排列顯示
$rows = [System.Collections.Generic.List[PSCustomObject]]::new()

$rows.Add([PSCustomObject]@{ 項目 = '農曆日期'; 值 = $lunar.ToString() })
$rows.Add([PSCustomObject]@{ 項目 = '宜'; 值 = $lunar.DayYi -join '、' })
$rows.Add([PSCustomObject]@{ 項目 = '忌'; 值 = $lunar.DayJi -join '、' })
$rows.Add([PSCustomObject]@{ 項目 = '天干紀年(年柱)'; 值 = $lunar.YearInGanZhi })
$rows.Add([PSCustomObject]@{ 項目 = '年生肖'; 值 = $lunar.YearShengXiao })
$rows.Add([PSCustomObject]@{ 項目 = '天干紀月(月柱)'; 值 = $lunar.MonthInGanZhi })
$rows.Add([PSCustomObject]@{ 項目 = '月生肖'; 值 = $lunar.MonthShengXiao })
$rows.Add([PSCustomObject]@{ 項目 = '天干紀日(日柱)'; 值 = $lunar.DayInGanZhi })
$rows.Add([PSCustomObject]@{ 項目 = '日生肖'; 值 = $lunar.DayShengXiao })
$rows.Add([PSCustomObject]@{ 項目 = '時辰地支'; 值 = $lunar.TimeZhi })
$rows.Add([PSCustomObject]@{ 項目 = '時辰生肖'; 值 = $lunar.TimeShengXiao })
$rows.Add([PSCustomObject]@{ 項目 = '年納音'; 值 = $lunar.YearNaYin })
$rows.Add([PSCustomObject]@{ 項目 = '月納音'; 值 = $lunar.MonthNaYin })
$rows.Add([PSCustomObject]@{ 項目 = '日納音'; 值 = $lunar.DayNaYin })
$rows.Add([PSCustomObject]@{ 項目 = '時辰納音'; 值 = $lunar.TimeNaYin })
$rows.Add([PSCustomObject]@{ 項目 = '星期'; 值 = $lunar.WeekInChinese })

foreach ($f in $lunar.Festivals) {
    $rows.Add([PSCustomObject]@{ 項目 = '節日'; 值 = $f })
}
foreach ($f in $lunar.OtherFestivals) {
    $rows.Add([PSCustomObject]@{ 項目 = '其他節日'; 值 = $f })
}
if ($lunar.JieQi.Length -gt 0) {
    $rows.Add([PSCustomObject]@{ 項目 = '節氣'; 值 = $lunar.JieQi })
}

$rows.Add([PSCustomObject]@{ 項目 = '宮'; 值 = $lunar.Gong })
$rows.Add([PSCustomObject]@{ 項目 = '獸'; 值 = $lunar.Shou })
$rows.Add([PSCustomObject]@{ 項目 = '宿'; 值 = $lunar.Xiu })
$rows.Add([PSCustomObject]@{ 項目 = '政'; 值 = $lunar.Zheng })
$rows.Add([PSCustomObject]@{ 項目 = '動物'; 值 = $lunar.Animal })
$rows.Add([PSCustomObject]@{ 項目 = '宿吉凶'; 值 = $lunar.XiuLuck })
$rows.Add([PSCustomObject]@{ 項目 = '彭祖百忌天干'; 值 = $lunar.PengZuGan })
$rows.Add([PSCustomObject]@{ 項目 = '彭祖百忌地支'; 值 = $lunar.PengZuZhi })
$rows.Add([PSCustomObject]@{ 項目 = '日喜神方位'; 值 = "$($lunar.DayPositionXi)（$($lunar.DayPositionXiDesc)）" })
$rows.Add([PSCustomObject]@{ 項目 = '日陽貴神方位'; 值 = "$($lunar.DayPositionYangGui)（$($lunar.DayPositionYangGuiDesc)）" })
$rows.Add([PSCustomObject]@{ 項目 = '日陰貴神方位'; 值 = "$($lunar.DayPositionYinGui)（$($lunar.DayPositionYinGuiDesc)）" })
$rows.Add([PSCustomObject]@{ 項目 = '日福神方位'; 值 = "$($lunar.DayPositionFu)（$($lunar.DayPositionFuDesc)）" })
$rows.Add([PSCustomObject]@{ 項目 = '日財神方位'; 值 = "$($lunar.DayPositionCai)（$($lunar.DayPositionCaiDesc)）" })
$rows.Add([PSCustomObject]@{ 項目 = '日沖'; 值 = $lunar.DayChongDesc })
$rows.Add([PSCustomObject]@{ 項目 = '日煞'; 值 = $lunar.DaySha })

# 計算項目欄最大寬度（中文字佔2，英文字佔1），對齊用
function Get-DisplayWidth([string]$s) {
    $w = 0
    foreach ($c in $s.ToCharArray()) {
        if ([int][char]$c -gt 127) { $w += 2 } else { $w += 1 }
    }
    return $w
}

$colWidth = ($rows | ForEach-Object { Get-DisplayWidth $_.項目 } | Measure-Object -Maximum).Maximum

foreach ($row in $rows) {
    $label = $row.項目
    $pad = ' ' * ($colWidth - (Get-DisplayWidth $label) + 2)
    Write-Host $label -ForegroundColor Cyan -NoNewline
    Write-Host $pad   -NoNewline
    Write-Host $row.值 -ForegroundColor Yellow
}



