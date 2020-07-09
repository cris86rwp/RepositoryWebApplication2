Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var m_00= new Menu();var mQ00= new Menu();var m_07= new Menu();var m= new Menu();var mQ01= new Menu();var mQ02= new Menu();
var tmp;
m_00.add(tmp = new MenuItem("Quarter Master",null,null, m_07) );
tmp.mnemonic = '';
m_00.add(tmp = new MenuItem("Rule Table",null,null, m) );
tmp.mnemonic = '';
mQ00.add(tmp = new MenuItem("Priority Register",null,null, mQ01) );
tmp.mnemonic = '';
mQ00.add(tmp = new MenuItem("Quarter Allotment",null,null, mQ02) );
tmp.mnemonic = '';
mQ00.add(tmp = new MenuItem("Quarters Rent-Generation and Print","/ppms/quarters/hr_rpt_quarter_recovery.aspx"));tmp.mnemonic = '';m_07.add(tmp = new MenuItem("Create","/ppms/quarterMaster.aspx?mode=add"));tmp.mnemonic = '';m_07.add(tmp = new MenuItem("Edit","/ppms/quarterMaster.aspx?mode=edit"));tmp.mnemonic = '';m_07.add(tmp = new MenuItem("View","/ppms/quarterMaster.aspx?mode=view"));tmp.mnemonic = '';mQ01.add(tmp = new MenuItem("Add","/ppms//quarters/QuarterPriorityRegister.aspx?mode=add"));tmp.mnemonic = '';mQ01.add(tmp = new MenuItem("Edit","/ppms/quarters/QuarterPriorityRegister.aspx?mode=edit"));tmp.mnemonic = '';mQ01.add(tmp = new MenuItem("Delete","/ppms/quarters/QuarterPriorityRegister.aspx?mode=delete"));tmp.mnemonic = '';mQ01.add(tmp = new MenuItem("Query","/ppms/quarters/QuarterPriorityRegister.aspx?mode=view"));tmp.mnemonic = '';mQ02.add(tmp = new MenuItem("Create Noting","/ppms/quarters/quarterAllotmentNoting.aspx?mode=add"));tmp.mnemonic = '';mQ02.add(tmp = new MenuItem("Add Employee","/ppms/quarters/quarterAllotmentNoting.aspx?mode=add"));tmp.mnemonic = '';mQ02.add(tmp = new MenuItem("Modify Employee","/ppms/quarters/quarterAllotmentNoting.aspx?mode=edit"));tmp.mnemonic = '';mQ02.add(tmp = new MenuItem("Delete Employee","/ppms/quarters/quarterAllotmentNoting.aspx?mode=delete"));tmp.mnemonic = '';mQ02.add(tmp = new MenuItem("Print Noting","/ppms/PPQTR1"));tmp.mnemonic = '';mQ02.add(tmp = new MenuItem("Generate Allotment Memo","/ppms/quarters/quarterOfficeOrderNumber.aspx"));tmp.mnemonic = '';mQ02.add(tmp = new MenuItem("Print Allotment Memo","/ppms/QuarterAllotment/QuarAllotRept.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Setup", m_00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Quarters", mQ00) );
tmp.mnemonic = '';

menuBar.write();
