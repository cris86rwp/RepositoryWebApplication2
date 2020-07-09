Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mF00= new Menu();var mF03= new Menu();
var tmp;
mF00.add(tmp = new MenuItem("Accounts Transaction",null,null, mF03) );
tmp.mnemonic = '';
mF03.add(tmp = new MenuItem("Create","/ppms/pf/pfAccountsTransactionMaintenance.aspx?mode=add"));tmp.mnemonic = '';mF03.add(tmp = new MenuItem("Modify","/ppms/pf/pfAccountsTransactionMaintenance.aspx?mode=edit"));tmp.mnemonic = '';mF03.add(tmp = new MenuItem("Delete","/ppms/pf/pfAccountsTransactionMaintenance.aspx?mode=delete"));tmp.mnemonic = '';mF03.add(tmp = new MenuItem("View","/ppms/pf/pfAccountsTransactionMaintenance.aspx?mode=view"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Provident Fund", mF00) );
tmp.mnemonic = '';

menuBar.write();
