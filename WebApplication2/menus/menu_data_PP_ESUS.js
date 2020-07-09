Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mU00= new Menu();var mES01= new Menu();
var tmp;
mES01.add(tmp = new MenuItem("Ledger","/ppms/eSuspense/ledger.aspx?mode=Ledger"));tmp.mnemonic = ' ';mU00.add(tmp = new MenuItem("E Suspense Process","/ppms/eSuspense/eSuspense.aspx"));tmp.mnemonic = '';mU00.add(tmp = new MenuItem("Reports",null,null, mES01) );
tmp.mnemonic = ' ';
mU00.add(tmp = new MenuItem("H.B.A Recovery","/ppms/eSuspense/Recovery.aspx"));tmp.mnemonic = '';mES01.add(tmp = new MenuItem("CheckList","/ppms/eSuspense/ledger.aspx?mode=Checklist"));tmp.mnemonic = ' ';mES01.add(tmp = new MenuItem("Railway Board Expenses","/ppms/eSuspense/RailwayBoardExpenses.aspx"));tmp.mnemonic = ' ';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("E Suspense", mU00) );
tmp.mnemonic = '';

menuBar.write();
