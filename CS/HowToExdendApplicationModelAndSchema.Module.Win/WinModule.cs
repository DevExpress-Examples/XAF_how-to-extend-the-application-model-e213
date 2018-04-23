using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace HowToExdendApplicationModelAndSchema.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class HowToExdendApplicationModelAndSchemaWindowsFormsModule : ModuleBase
    {
        public HowToExdendApplicationModelAndSchemaWindowsFormsModule()
        {
            InitializeComponent();
        }
        public override Schema GetSchema()
        {
            const string CommonTypeInfos =
            @"<Element Name=""Application"">
                <Element Name=""Views"" >
                    <Element Name=""ListView"" >
                    <Attribute Name=""IsGroupFooterVisible"" Choice=""True,False""/>
                        <Element Name=""Columns"" >
                            <Element Name=""ColumnInfo"" >
                            <Attribute Name=""GroupFooterSummaryType"" Choice=""Sum,Min,Max,Count,Average,Custom,None"" />
                            </Element>
                        </Element>
                    </Element>
                </Element>
            </Element>";
            return new Schema(new DictionaryXmlReader().ReadFromString(CommonTypeInfos));
        }
    }
}
