Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var m_00= new Menu();var m278= new Menu();var mC01= new Menu();var m_06= new Menu();var m281= new Menu();var mC39= new Menu();
var tmp;
m_00.add(tmp = new MenuItem("Bank Directory",null,null, m_06) );
tmp.mnemonic = '';
m278.add(tmp = new MenuItem("Employee Details",null,null, m281) );
tmp.mnemonic = '';
mC01.add(tmp = new MenuItem("Bank",null,null, mC39) );
tmp.mnemonic = '';
m_06.add(tmp = new MenuItem("Create","/ppms/bankDirectory.aspx?mode=add"));tmp.mnemonic = '';m_06.add(tmp = new MenuItem("Edit","/ppms/bankDirectory.aspx?mode=edit"));tmp.mnemonic = '';m_06.add(tmp = new MenuItem("View","/ppms/bankDirectory.aspx?mode=view"));tmp.mnemonic = '';m_06.add(tmp = new MenuItem("Check List","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistBankdetails"));tmp.mnemonic = '';m281.add(tmp = new MenuItem("Bank Details","/ppms/personnel/bankDetails.aspx"));tmp.mnemonic = '';mC39.add(tmp = new MenuItem("Add","/ppms/transactions/BankAccount.aspx?mode=add"));tmp.mnemonic = '';mC39.add(tmp = new MenuItem("Edit","/ppms/transactions/BankAccount.aspx?mode=edit"));tmp.mnemonic = '';mC39.add(tmp = new MenuItem("Delete","/ppms/transactions/BankAccount.aspx?mode=delete"));tmp.mnemonic = '';mC39.add(tmp = new MenuItem("Query","/ppms/transactions/BankAccount.aspx?mode=view"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Setup", m_00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Personnel", m278) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Transactions", mC01) );
tmp.mnemonic = '';

menuBar.write();
