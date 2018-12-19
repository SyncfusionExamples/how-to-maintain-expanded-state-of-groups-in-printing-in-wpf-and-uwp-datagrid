#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Data.Linq;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Data;
using System.Collections;
using System.Collections.Generic;

namespace SfDataGridDemo
{
    //CustomPrintManager Clas
    internal class CustomPrintManager : GridPrintManager
    {
        //CustomPrintManager class constructor
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
