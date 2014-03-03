using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Attributes;
//namespace DotNet.Highcharts;
namespace WebApplication1
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                Answer.Text = "click on calculate for answer";
            }
            else
            {
            }
        }
        protected void Calculate(object sender, EventArgs e)
        {
            double L,C,A;
            var mydata = new ArrayList();
                ;
 
            /*
            if (Inductance.Text.Length > 0 && Capacitance.Text.Length > 0)
            {

                A = Convert.ToDouble(Inductance.Text) + Convert.ToDouble(Capacitance.Text);
                Answer.Text = A.ToString("0.000");
            }
            else
            {
                Answer.Text = "Invalid Input";
            }
            //Debug.Write("Calculate Pressed\n");
             *
             * */
            //s = Inductance.Text;
            //C = Double.TryParse(s, L);
            if (Double.TryParse(Inductance.Text, out L))
            {
            }
            if( (Double.TryParse(Capacitance.Text,out  C))&&(Double.TryParse(Inductance.Text, out L)))
            {
               //A = L + C;
                A =  1.0 / (6.2831853 * Math.Sqrt(L * C/1000));
                Answer.Text = A.ToString("0.000") + " MHz";
                for( int i = 0; i < 10; i++ ) {
                    //mydata.Add(1.0 * i);
                    mydata.Add( 1.0 / (6.2831853 * Math.Sqrt(L * C/1000 * 0.2 * (i+1))));
                }

            } else 
            {
                Answer.Text = "Invalid Input";
            }
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
                .InitChart(new Chart
                    {
                        DefaultSeriesType = ChartTypes.Line,
                        Height = 300,
                        MarginRight = 130,
                        //MarginBottom = 25,
                        ClassName = "chart"
                    })
                .SetTitle(new Title
                {
                    Text = "Resonant Frequency",
                    X = -20
                })

                .SetXAxis(new XAxis
                {
                    Categories = new[] { "20%","40%","60%","80%","100%","120%","140%","160%","180%","200%" },
                    //Categories = mydata;
                    Title = new XAxisTitle {Text =  "% Capacitance"},
                    Min = 0,
                    Max = 9,
                    //TickLength = 20,
                    //TickWidth = 20,
                    //MinTickInterval = 20
                    TickInterval = 1
                }
                )
                .SetYAxis(new YAxis
                    {
                        Title = new YAxisTitle { Text = "Frequency MHz" },
                        PlotLines = new []
                        {
                            new YAxisPlotLines 
                            {
                                
                                    Value = 0,
                                    Width = 1,
                                    //Color = ColorTranslator.FromHtml("808080")
                          
                            }
                        }
                    }
                        )
                .SetSeries(new Series
                {
                   // Data = new Data(new object[] { 29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4 })
                    //Data = new Data(new object mydata);
    
                    Data = new Data(new object[] { mydata[0], mydata[1], mydata[2], mydata[3], mydata[4],
                    mydata[5],mydata[6], mydata[7], mydata[8], mydata[9]})
                });
            ltrChart.Text = chart.ToHtmlString();


        }
    }
}