# How to maintain expanded state of groups in printing in wpf and uwp datagrid?

This example illustrates how to maintain expanded state of groups in printing in [WPF Datagrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid).

All the groups will be printed in expanded state by default in [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid). You can also avoid this and maintain the expanded states of group as in view when printing by inheriting the [GridPrintManager](http://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.GridPrintManager.html) and overriding the [GetSourceListForPrinting](http://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.GridPrintManager.html) method.
