using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ExcelAnalyzer
{
    public static class ExcelAnalyzerConstants
    {

#if DEBUG
        public static readonly string HelpFile = AddInDirectory + @"\Documentation\Analyzer for Microsoft Office Excel.chm";
#else
        public static readonly string HelpFile = AddInDirectory + @"\Analyzer for Microsoft Office Excel.chm";
#endif
        
        public const string AddInCaption = @"Анализ данных";
        public const string ArmApplicationCaption = @"СПО АРМ ""Статистика Генеральной прокуратуры Российской Федерации""";
        public const string ArmApplication = @"АРМ ""Статистика ГП РФ""";

        public const string WorkbookTools = @"Обработка данных";

        public const string Values = @"Значения";
        public const string Increases = @"Прирост";
        public const string Proportions = @"Удельный вес";
        public const string Expressions = @"Выражение";

        public const string clnWorksheet = @"Заголовок листа";
        public const string clnValue = @"Значение";
        //public const string WorksheetLabel = @"Заголовок листа";
        public const string clnDescription = @"Примечание";


        public const string ExcelAnalyzer_Button_OfficeImageId = @"Calculator";
        public const string ArmDataRefresh_Button_OfficeImageId = @"DataRefreshAll";

        public const string Help_Button_OfficeImageId = @"Help";
        public const string About_Button_OfficeImageId = @"Info";
        public const int AddSheet_Button_FaceId = 2646;
        public const int SortDialog_Button_FaceId = 210;
        

        private static string _AddInDirectory = null;

        public static string AddInDirectory
        {
            get
            {
                if (_AddInDirectory == null)
                {
                    Assembly assem = typeof(ExcelAnalyzerConstants).Assembly;

                    _AddInDirectory = assem.CodeBase.Substring(8);
                    _AddInDirectory = _AddInDirectory.Substring(0, _AddInDirectory.LastIndexOf("/"));

                    //    For i As Integer = 0 To My.Application.Info.LoadedAssemblies.Count - 1
                    //   Dim a As System.Reflection.Assembly = My.Application.Info.LoadedAssemblies.Item(i)

                    //                   If a.FullName.Length > 87 AndAlso a.FullName.Substring(0, 87) = My.Application.Info.AssemblyName & ", Version=" & My.Application.Info.Version.ToString & ", Culture=neutral, PublicKeyToken=" Then
                    //                     _AddInDirectory = IO.Path.GetDirectoryName(a.CodeBase.Substring("file:///".Length))
                    //                    Exit For
                    //              End If
                    //        Next
                }
                return _AddInDirectory;
            }
        }
    }
}
