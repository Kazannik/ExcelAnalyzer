using MSDAOSP;
using MSDATASRC = msdatasrc;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;

// Added COM Reference to C:\Windows\SysWOW64\msdatsrc.tlb - MSDATASRC - Microsoft Data Source Interfaces for ActiveX Data Binding Type Library
// Added COM Reference to C:\Windows\SysWOW64\simpdata.tlb - MSDAOSP   - Microsoft OLE DB Simple Provider 1.5 Library

namespace ArmDataOLEDBProvider
{
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(MSDATASRC.DataSource))]
    [ComVisible(true)]
    public class ArmDataSource : MSDATASRC.DataSource
    {
        List<MSDATASRC.DataSourceListener> _listListeners = new List<MSDATASRC.DataSourceListener>();
        Dictionary<string, ArmDataRecordset> _dataMembers = new Dictionary<string, ArmDataRecordset>();
        
        ~ArmDataSource()
        {
            while (_listListeners.Count > 0)
            {
                MSDATASRC.DataSourceListener head = _listListeners[0];
                head = null; // calls IUnknown::Release (hopefully)
                _listListeners.RemoveAt(0);
            }
        }
        /// <summary>
        /// Добавляет слушателя в список уведомлений.
        /// Коды возврата:
        /// S_OK Метод выполнен успешно.
        /// E_FAIL Произошла ошибка поставщика.
        /// Комментарий:
        /// Проверять наличие повторяющихся элементов и возвращать ошибку необязательно.
        /// Если источник данных знает, что никогда не будет выдавать уведомления
        /// (например, элементы данных всегда доступны), ему не нужно реализовывать этот метод,
        /// и он может просто вернуть S_OK. Однако, если он выдает уведомления,
        /// он должен их многоадресно передать. 
        /// HRESULT, возвращенные многоадресной рассылкой, игнорируются 
        /// и не завершают многоадресную рассылку.
        /// </summary>
        /// <param name="pDSL">*[in] Указатель на интерфейс слушателя.
        /// В случае любого события к этому интерфейсу вызываются методы.</param>
        void MSDATASRC.DataSource.addDataSourceListener(MSDATASRC.DataSourceListener pDSL)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms716931(v=vs.85)
            _listListeners.Add(pDSL);
        }
        
        /// <summary>
        /// Возвращает объект доступа к данным (например, позицию строки) для заданного элемента данных.
        /// Коды возврата:
        /// S_OK Метод выполнен успешно.
        /// E_FAIL Произошла ошибка поставщика.
        /// E_NOINTERFACE Не поддерживает указанный объект доступа к данным.
        /// Комментарий:
        /// Член данных по умолчанию указывается либо строкой нулевой длины, либо строкой Null.
        /// (Они эквивалентны.) Если источник данных не поддерживает требуемый объект доступа к данным,
        /// он возвращает E_NOINTERFACE.
        /// Возвращаемое значение из IDataSource :: getDataMember всегда является указателем
        /// на IUnknown.Ответственность за запрос соответствующего интерфейса лежит на вызывающем методе.
        /// То есть параметр IID не указывает, какой интерфейс, а скорее, какой тип объекта доступа
        /// к данным следует вернуть. 
        /// </summary>
        /// <param name="bstrDM">[in] Строка, описывающая элемент данных, представляющий один 
        /// или несколько наборов данных, поддерживаемых источником данных.
        /// Эта строка интерпретируется как нечувствительная к регистру.</param>
        /// <param name="riid">[in] Идентификатор интерфейса указанного объекта доступа к данным.</param>
        /// <param name="ppunk">*[out] Указатель возвращаемого интерфейса.</param>
        /// <returns></returns>
        dynamic MSDATASRC.DataSource.getDataMember(string bstrDM, ref Guid riid)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms724549(v=vs.85)

            ArmDataRecordset retval = null;

            if (_dataMembers.ContainsKey(bstrDM))
            {
                retval = _dataMembers[bstrDM];
            }
            else
            {
                retval = new ArmDataRecordset();
                retval.Initialize(bstrDM);
                _dataMembers.Add(bstrDM, retval);
            }
            return retval;
        }

        /// <summary>
        /// Возвращает имя известного члена данных.
        /// Коды возврата:
        /// S_OK Метод выполнен успешно.
        /// E_FAIL Произошла ошибка поставщика.
        /// Комментарий:
        /// Указан параметр индекса с отсчетом от нуля.
        /// Индекс должен находиться в диапазоне от 0 до getDataMemberCount - 1,
        /// иначе этот метод вернет E_FAIL. Элемент данных по умолчанию ("")
        /// никогда не должен возвращаться из этого метода.
        /// </summary>
        /// <param name="lIndex">[in] Индекс в списке имен элементов данных.</param>
        /// <param name="pbstrDM">*[out] Строка, описывающая имя элемента данных.
        /// Эта строка интерпретируется как нечувствительная к регистру.</param>
        /// <returns></returns>
        string MSDATASRC.DataSource.getDataMemberName(int lIndex)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms715947(v=vs.85)
            List<string> keys = new List<string>();
            keys.AddRange(_dataMembers.Keys);
            return keys[lIndex];
        }

        /// <summary>
        /// Возвращает количество известных членов данных.
        /// Коды возврата:
        /// S_OK Метод выполнен успешно.
        /// E_FAIL Произошла ошибка поставщика.
        /// Комментарий:
        /// Для источников данных, которые не поддерживают перечисление,
        /// должен быть возвращен 0. В противном случае должно быть
        /// возвращено количество хорошо известных членов данных.
        /// </summary>
        /// <param name="plCount">*[out] Количество известных членов данных.</param>
        /// <returns></returns>
        int MSDATASRC.DataSource.getDataMemberCount()
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms721173(v=vs.85)
            return _dataMembers.Count;
        }

        /// <summary>
        /// Удаляет слушателя из списка уведомлений.
        /// Коды возврата:
        /// S_OK Метод выполнен успешно.
        /// E_FAIL Произошла ошибка поставщика.
        /// Комментарий:
        /// Проверять, добавлен ли слушатель и возвращать E_FAIL необязательно.
        /// Если в списке есть дубликаты, один удаляется, но какой из них не указан.
        /// Если источник данных не выдает уведомления, он может просто вернуть S_OK
        /// из этого метода.
        /// </summary>
        /// <param name="pDSL">*[in] Указатель на интерфейс слушателя.</param>
        void MSDATASRC.DataSource.removeDataSourceListener(MSDATASRC.DataSourceListener pDSL)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms724012(v=vs.85)
            _listListeners.Remove(pDSL);
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(MSDAOSP.OLEDBSimpleProvider))]
    [ComVisible(true)]
    public class ArmDataRecordset : MSDAOSP.OLEDBSimpleProvider
    {
        private List<object[]> _tabularData = null;
        private string _bstrDM = null;
        private List<MSDAOSP.OLEDBSimpleProviderListener> _listListeners = new List<MSDAOSP.OLEDBSimpleProviderListener>();

        ~ArmDataRecordset()
        {
            while (_listListeners.Count > 0)
            {
                MSDAOSP.OLEDBSimpleProviderListener head = _listListeners[0];
                head = null;
                _listListeners.RemoveAt(0);
            }
        }

        public void Initialize(string bstrDM)
        {
            //
            // we got some hard coded statrting tables for demonstration purposes only
            // in a real situation one would open a file or something
            //
            switch (bstrDM.ToLower())
            {
                case "customers":

                    _tabularData = new List<object[]>();
                    _tabularData.Add(new object[4] { "CustomerId", "CustomerName", "ContactName", "Country" });
                    _tabularData.Add(new object[4] { 1, "Big Corp", "Mandy", "USA" });
                    _tabularData.Add(new object[4] { 2, "Medium Corp", "Bob", "Canada" });
                    _tabularData.Add(new object[4] { 3, "Small Corp", "Jose", "Mexico" });

                    break;
                case "orders":

                    _tabularData = new List<object[]>();
                    _tabularData.Add(new object[3] { "OrderId", "CustomerId", "OrderDate" });
                    _tabularData.Add(new object[3] { 420, 2, new DateTime(2018, 10, 10) });
                    _tabularData.Add(new object[3] { 421, 3, new DateTime(2018, 10, 11) });
                    _tabularData.Add(new object[3] { 422, 1, new DateTime(2018, 10, 12) });
                    _tabularData.Add(new object[3] { 423, 2, new DateTime(2018, 10, 13) });

                    break;
                default:
                    // if unrecognised hand back default of colors
                    _tabularData = new List<object[]>();
                    _tabularData.Add(new object[2] { "ColorName", "ColorRGB" });
                    _tabularData.Add(new object[2] { "Red", "FF0000" });
                    _tabularData.Add(new object[2] { "Green", "00FF00" });
                    _tabularData.Add(new object[2] { "Blue", "0000FF" });
                    break;
            }

            _bstrDM = bstrDM;
        }

        /// <summary>
        /// Регистрирует интерфейс именованного обработчика событий
        /// для получения уведомлений об изменениях данных.
        /// 
        /// Коды возврата:
        /// S_OK Метод выполнен успешно.
        /// E_FAIL Произошла ошибка поставщика.
        /// Комментарий:
        /// Если обработчик событий был указан ранее, OLEDBSimpleProvider :: addOLEDBSimpleProviderListener
        /// освобождает этот обработчик событий до регистрации pospIListener .
        /// Простой поставщик должен реализовать этот метод для поддержки списка
        /// прослушивателей простых поставщиков.Если не реализовано, методы OLE DB,
        /// вызываемые потребителями, могут дать сбой, потому что уровень отображения
        /// не может уведомить слушателей о событиях.
        /// Например, IOpenRowset::OpenRowset вернет DB_E_OBJECTOPEN,
        /// если OLEDBSimpleProvider :: addOLEDBSimpleProviderListener не реализован.
        /// Для нескольких наборов строк OLE DB для одного и того же набора данных
        /// ваша реализация должна поддерживать несколько прослушивателей;
        /// в противном случае будет разрешен только один «активный» набор строк.
        /// </summary>
        /// <param name="pospIListener">[in] Регистрируемый интерфейс обработчика событий.</param>
        void OLEDBSimpleProvider.addOLEDBSimpleProviderListener(OLEDBSimpleProviderListener pospIListener)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms713697(v=vs.85)
            _listListeners.Add(pospIListener);
        }

        /// <summary>
        /// Удаляет указанное количество строк, начиная с iRow , из набора данных.
        /// 
        /// Коды возврата:
        /// S_OK Метод выполнен успешно.
        /// E_FAIL Произошла ошибка поставщика.
        /// Комментарий:
        /// OLEDBSimpleProvider :: deleteRows требует следующих уведомлений:
        /// aboutToDeleteRows
        /// deletedRows
        /// Дополнительные сведения и рекомендации по программированию
        /// отправки и получения уведомлений см.В разделе Notifications (OLE DB).
        /// </summary>
        /// <param name="iRow">[in] Позиция первой строки, с которой начинается удаление.
        /// Значение -1 указывает все строки.</param>
        /// <param name="cRows">[in] Количество удаляемых строк.
        /// Игнорируется при реализации поведения с подстановочными знаками ( значение iRow -1).
        /// pcRowsDeleted [out] Фактическое количество строк,
        /// которые были успешно удалены из набора данных.
        /// </param>
        /// <param name=""></param>
        /// <returns></returns>
        int OLEDBSimpleProvider.deleteRows(int iRow, int cRows)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms713665(v=vs.85)

            // Notify our Listeners:
            foreach (OLEDBSimpleProviderListener listener in _listListeners)
                listener.aboutToDeleteRows(iRow, cRows);
            _tabularData.RemoveRange(iRow, cRows);
            // Notify our Listeners:
            foreach (OLEDBSimpleProviderListener listener in _listListeners)
                listener.deletedRows(iRow, cRows);
            return cRows;
        }

        /// <summary>
        /// Ищет набор значений, указанных в varSval ,
        /// в столбце iColumn, начиная с iRow .
        /// После успешного завершения номер строки с соответствующим
        /// значением возвращается в piRowFound.
        /// 
        /// Коды возврата:
        /// S_OK Метод выполнен успешно.
        /// DISP_E_TYPEMISMATCH Поставщику не удалось сопоставить тип varSval с базовым типом столбца.
        /// E_FAIL Произошла ошибка поставщика.
        /// Комментарий:
        /// Используя собственный тип нижележащего столбца,
        /// OLEDBSimpleProvider :: find выполняет сравнение.
        /// Поставщики должны возвращать DISP_E_TYPEMISMATCH,
        /// если они не могут преобразовать varSval в базовый тип столбца. 
        /// При сравнении строковых значений всегда сравниваются значения,
        /// которые были бы возвращены при вызове OLEDBSimpleProvider::getVariant
        /// с OSPFORMAT_FORMATTED.Провайдеры не должны приводить значения varSval,
        /// полученные в результате предыдущего вызова OLEDBSimpleProvider::getVariant с OSPFORMAT_HTML.
        /// </summary>
        /// <param name="iRowStart">[in] Позиция первой строки набора данных, с которой начинается операция поиска.</param>
        /// <param name="iColumn">[in] Позиция первого столбца набора данных, с которого начинается операция поиска.</param>
        /// <param name="varSvalt">[in] Целевое значение или значения операции поиска.</param>
        /// <param name="findFlags">[in] Перечисление, состоящее из значений, определенных в следующей таблице
        /// Значение Имея в виду
        /// OSPFIND_DEFAULT = 0 Указывает, что операция поиска должна выполняться в порядке возрастания строк без учета регистра.
        /// OSPFIND_UP = 1 Указывает, что операция поиска должна выполняться в порядке убывания строк.
        /// OSPFIND_CASESENSITIVE = 2 Задает чувствительность к регистру при поиске.
        /// OSPFIND_UPCASESENSITIVE = 3 Указывает, что операция поиска должна выполняться в возрастающем порядке по строкам с учетом регистра.
        /// </param>
        /// <param name="compType">[in] Перечисление, состоящее из значений, определенных в следующей таблице.
        /// Значение Имея в виду
        /// OSPCOMP_EQ = 1
        /// OSPCOMP_DEFAULT = 1 Указывает, что выполняется поиск первого значения, равного varSval.
        /// OSPCOMP_LT = 2 Указывает, что поиск ведется для первого значения меньше, чем varSval.
        /// OSPCOMP_LE = 3 Указывает, что выполняется поиск первого значения, меньшего или равного varSval. 
        /// OSPCOMP_GE = 4 Указывает, что выполняется поиск первого значения, большего или равного varSval. 
        /// OSPCOMP_GT = 5 Указывает, что поиск выполняется для первого значения, большего, чем varSval.
        /// OSPCOMP_NE = 6 Указывает, что выполняется поиск первого значения, не равного varSval.
        /// </param>
        /// <param name="piRowFound">[out] Номер строки, содержащей совпадающее значение поиска.
        /// Если соответствующее совпадение не найдено, OLEDBSimpleProvider :: find должен вернуть константу -1.</param>
        /// <returns></returns>
        int OLEDBSimpleProvider.find(int iRowStart, int iColumn, object varSvalt, OSPFIND findFlags, OSPCOMP compType)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms709764(v=vs.85)
            // not yet implemented
            return -1;
        }

        /// <summary>
        /// Коды возврата:
        /// Комментарий:
        /// </summary>
        /// <returns></returns>
        int OLEDBSimpleProvider.getColumnCount()
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms715965(v=vs.85)

            object[] colHeaders = _tabularData[0];
            int totalColumnCount = colHeaders.Length;
            return totalColumnCount;
        }

        /// <summary>
        /// Коды возврата:
        /// Комментарий:
        /// </summary>
        /// <returns></returns>
        int OLEDBSimpleProvider.getEstimatedRows()
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms713703(v=vs.85)
            // should not include row header

            int totalRowCount = _tabularData.Count;
            return (totalRowCount - 1);
        }

        /// <summary>
        /// Коды возврата:
        /// Комментарий:
        /// </summary>
        /// <returns></returns>
        string OLEDBSimpleProvider.getLocale()
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms711216(v=vs.85)
            //return "en-us";
            var name = Thread.CurrentThread.CurrentCulture.Name;
            var locale = name.Split('-')[1];
            return locale;
        }

        /// <summary>
        /// Коды возврата:
        /// Комментарий:
        /// </summary>
        /// <returns></returns>
        int OLEDBSimpleProvider.getRowCount()
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms715931(v=vs.85)
            // should not include row header
            int totalRowCount = _tabularData.Count;
            return (totalRowCount - 1);
        }

        /// <summary>
        /// Коды возврата:
        /// Комментарий:
        /// </summary>
        /// <param name="iRow"></param>
        /// <param name="iColumn"></param>
        /// <returns></returns>
        OSPRW OLEDBSimpleProvider.getRWStatus(int iRow, int iColumn)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms709946(v=vs.85)
            return OSPRW.OSPRW_READWRITE;
        }

        /// <summary>
        /// Коды возврата:
        /// Комментарий:
        /// </summary>
        /// <param name="iRow"></param>
        /// <param name="iColumn"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        dynamic OLEDBSimpleProvider.getVariant(int iRow, int iColumn, OSPFORMAT format)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms725341(v=vs.85)

            if (iRow < _tabularData.Count)
            {
                object[] row = _tabularData[iRow];
                return row[iColumn - 1];  // columns start at 1 it seems
            }
            else
            {
                // oddly, when a record is removed we still get called for dead row
                // so until we diagnose and fix this bug return a null
                return null;
            }
        }

        /// <summary>
        /// Коды возврата:
        /// Комментарий:
        /// </summary>
        /// <param name="iRow"></param>
        /// <param name="cRows"></param>
        /// <returns></returns>
        int OLEDBSimpleProvider.insertRows(int iRow, int cRows)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms721207(v=vs.85)

            object[] colHeaders = _tabularData[0];
            int totalColumnCount = colHeaders.Length;

            object[] blankRow = new object[totalColumnCount];

            // Notify our Listeners:
            foreach (OLEDBSimpleProviderListener listener in _listListeners)
                listener.aboutToInsertRows(iRow, cRows);


            for (int i = 0; i < cRows; i++)
            {
                _tabularData.Insert(iRow, blankRow);
            }

            // Notify our Listeners:
            foreach (OLEDBSimpleProviderListener listener in _listListeners)
                listener.insertedRows(iRow, cRows);

            return cRows;
        }

        /// <summary>
        /// Коды возврата:
        /// Комментарий:
        /// </summary>
        /// <returns></returns>
        int OLEDBSimpleProvider.isAsync()
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms723042(v=vs.85)
            return 0; // not async
        }

        /// <summary>
        /// Коды возврата:
        /// Комментарий:
        /// </summary>
        /// <param name="pospIListener"></param>
        void OLEDBSimpleProvider.removeOLEDBSimpleProviderListener(OLEDBSimpleProviderListener pospIListener)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms712993(v=vs.85)
            _listListeners.Remove(pospIListener);
        }

        /// <summary>
        /// Устанавливает значение ячейки в строке и столбце, указанном в значение Variant,
        /// указанное в pVar, в типе, запрошенном значением fFormatted .
        /// Коды возврата:
        /// S_OK Метод выполнен успешно.
        /// E_FAIL Значение не может быть установлено, или поставщик был доступен только для чтения.
        /// Комментарий:
        /// setVariant использует следующее перечисление:
        /// typedef enum OSPFORMAT
        /// {
        /// OSPFORMAT_RAW = 0,
        /// OSPFORMAT_DEFAULT = 0,
        /// OSPFORMAT_FORMATTED = 1,
        /// OSPFORMAT_HTML = 2
        /// };
        /// Предыдущие значения определены в следующей таблице.
        /// КОММЕНТАРИИ
        /// Значение
        /// Имея в виду
        /// OSPFORMAT_RAW
        /// OSPFORMAT_DEFAULT Для установки значения следует использовать тип нижележащего столбца (по умолчанию).
        /// OSPFORMAT_FORMATTED Входная строка помещается в ячейку на основе эвристики поставщика.
        /// OSPFORMAT_HTML Зависит от провайдера.Входная строка может быть в формате HTML.
        /// setVariant не поддерживает ссылки.
        /// setVariant требует следующих уведомлений:
        /// aboutToChangeCell
        /// cellChanged
        /// При любом варианте форматирования провайдер должен выполнить соответствующее
        /// приведение к базовому типу столбца.В случаях, когда приведение не может
        /// быть успешно завершено, должен быть возвращен соответствующий код ошибки.
        /// Со значением OSPFORMAT_FORMATTED провайдер может интерпретировать входную
        /// строку так, как он считает нужным. В качестве альтернативы поставщик может
        /// попытаться проанализировать входную строку и эвристически определить
        /// подходящий тип данных и значение для помещения в ячейку?
        /// например, при обновлении ячеек отформатированной электронной таблицы.
        /// Когда запрашивается OSPFORMAT_HTML, провайдер может дополнительно
        /// вернуть простую строку (например, не украшенную тегами HTML).
        /// Значение данных NULL указывается путем передачи Variant типа VT_NULL
        /// в pVar для любого из типов fFormatted.
        /// Не используйте значение -1 в качестве аргумента с аргументами 
        /// iRow и iColumn для setVariant. Вы должны устанавливать ячейки таблицы
        /// индивидуально; они не могут быть установлены по строкам или столбцам за раз.
        /// Дополнительные сведения и рекомендации по программированию отправки и
        /// получения уведомлений см.В разделе Notifications (OLE DB).
        /// </summary>
        /// <param name="iRow">[in] Позиция указанной строки.</param>
        /// <param name="iColumn">[in] Позиция указанного столбца.</param>
        /// <param name="format">[in] Перечислимое значение, определяющее формат,
        /// в котором следует возвращать тип столбца, лежащего в основе значения ячейки.
        /// (См. Таблицу ниже.)</param>
        /// <param name="pVar">*[вход / выход] На основе значения , указанного в PVAR параметра,
        /// PVAR будет содержать одно из следующих действий :
        /// -Значение с базовым типом столбца.
        /// -Строка, соответствующая базовому типу столбца.
        /// -Фрагмент HTML, соответствующий базовому типу столбца.</param>
        void OLEDBSimpleProvider.setVariant(int iRow, int iColumn, OSPFORMAT format, object pVar)
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms714366(v=vs.85)
            // Notify our Listeners:
            foreach (OLEDBSimpleProviderListener listener in _listListeners)
                listener.aboutToChangeCell(iRow, iColumn);

            object[] row = _tabularData[iRow];
            row[iColumn - 1] = pVar;

            _tabularData[iRow] = row;

            // Notify our Listeners:
            foreach (OLEDBSimpleProviderListener listener in _listListeners)
                listener.cellChanged(iRow, iColumn);
        }

        /// <summary>
        /// Запрашивает, чтобы простой провайдер прекратил асинхронную передачу данных.
        /// Коды возврата:
        /// S_OK Метод выполнен успешно.
        /// E_FAIL Произошла ошибка поставщика, или OSP не смог остановить асинхронную передачу.
        /// Комментарий:
        /// Поставщики должны приложить все усилия, чтобы раскрыть переданные данные
        /// до получения этого запроса. Провайдер должен предоставить допустимый
        /// согласованный интерфейс OSP для таких данных, включая соответствующее
        /// количество столбцов и строк и статус чтения / записи.
        /// Провайдеры, которые не могут предоставить данные до получения этого запроса,
        /// должны прекратить передачу данных и прервать все последующие вызовы интерфейса OSP.
        /// OLEDBSimpleProvider :: stopTransfer требует уведомления
        /// OLEDBSimpleProviderListener :: transferComplete, если данные поставщика
        /// будут заполнять потребительское приложение или управлять асинхронно.
        /// </summary>
        void OLEDBSimpleProvider.stopTransfer()
        {   // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms722788(v=vs.85)
            // we do not handle async ops
        }
    }
}

