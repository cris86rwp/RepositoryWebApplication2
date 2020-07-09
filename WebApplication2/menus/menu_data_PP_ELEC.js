Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mE01= new Menu();
var tmp;
mE01.add(tmp = new MenuItem("Generate Open Reading","/ppms/electricity/generateOpenReading.aspx"));tmp.mnemonic = '';mE01.add(tmp = new MenuItem("Turn Around Doc. Printing","/ppms/electricity/turnAroundDocPrinting.aspx"));tmp.mnemonic = '';mE01.add(tmp = new MenuItem("Closing Reading Entry","/ppms/electricity/closingReadingEntry.aspx"));tmp.mnemonic = '';mE01.add(tmp = new MenuItem("Calculate Elec. Charges","/ppms/electricity/electricityChargesCalc.aspx"));tmp.mnemonic = '';mE01.add(tmp = new MenuItem("Electric Bill Printing","/ppms/electricity/electricBillPrinting.aspx"));tmp.mnemonic = '';mE01.add(tmp = new MenuItem("Not recoverd under pay","/ppms/electricity/notrecovered.rpt"));tmp.mnemonic = '';mE01.add(tmp = new MenuItem("Electricity (Qtrs) Recoveries Monthwise","/ppms/electricity/hr_emp_rpt_quarter_electricity.aspx"));tmp.mnemonic = '';mE01.add(tmp = new MenuItem("Solar Quarter MOnthwise Recoveries","/ppms/electricity/hr_emp_rpt_quarter_solar.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Electricity", mE01) );
tmp.mnemonic = '';

menuBar.write();
