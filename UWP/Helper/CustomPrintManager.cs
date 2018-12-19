using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace SfDataGridDemo
{
    class CustomPrintManager : GridPrintManager
    {                
        public CustomPrintManager(SfDataGrid grid)
            : base(grid)
        {                               
        }
        protected override IList GetSourceListForPrinting()
        {
            if (View.GroupDescriptions.Any())
            {
                var records = ToIEnumerable(View.TopLevelGroup.GetEnumerator()).ToList();
                List<NodeEntry> expandedGroups = new List<NodeEntry>();
                foreach (var record in records)
                {
                    if (record is RecordEntry)
                    {
                        var group = record.Parent as Group;
                        if (group != null && group.IsExpanded)
                            expandedGroups.Add(record);
                    }
                    else if (record is Group)
                    {
                        var group = record as Group;
                        if (group.IsTopLevelGroup || group.Level == 1)
                        {
                            expandedGroups.Add(group);
                        }
                        //For Multi-ColumnGrouping
                        else
                        {
                            var parentGroup = group.Parent as Group;
                            if (parentGroup != null && parentGroup.IsExpanded)
                                expandedGroups.Add(group);
                        }
                    }
                }
                return expandedGroups;
            }
            return base.GetSourceListForPrinting();
        }
    }
}
