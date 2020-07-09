Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mA03= new Menu();
var tmp;
mA03.add(tmp = new MenuItem("Create Noting-Unpaid Wage","/ppms/miscEDs/miscEdUnPaidWagesNoting.aspx"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Print Noting","/ppms/Reports/Formats/miscEDs/miscEdPrintNoting.aspx?mode=miscEdNoting.rpt"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Generate Memorandum","/ppms/miscEDs/miscEDOffOrdNumber.aspx"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Print Memorandum","/ppms/Reports/Formats/miscEds/miscEdPrintMemorandum.aspx?mode=miscEdMemorandum.rpt"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Post Memo. to Payroll","/ppms/miscEDs/postMemo.aspx?post=P"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Misc. E/Ds", mA03) );
tmp.mnemonic = '';

menuBar.write();
