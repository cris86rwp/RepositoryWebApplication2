Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mPF01= new Menu();var mF00= new Menu();
var tmp;
mF00.add(tmp = new MenuItem("PF Ledger Closing","/ppms/pf/PfLedgerClosing.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("PF Login", mPF01) );
tmp.mnemonic = ' ';
menuBar.add( tmp = new MenuButton("Provident Fund", mF00) );
tmp.mnemonic = '';

menuBar.write();
