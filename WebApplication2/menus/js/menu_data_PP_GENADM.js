Menu.prototype.cssFile = '/wap/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/wap/menus/skins/officexp/officexp.css';
var m_00= new Menu();var m_07= new Menu();
var tmp;
m_00.add(tmp = new MenuItem("Quarter Master",null,null, m_07) );
tmp.mnemonic = '';
m_07.add(tmp = new MenuItem("Create","/wap/ppms/quarterMaster.aspx?mode=add"));tmp.mnemonic = '';m_07.add(tmp = new MenuItem("Edit","/wap/ppms/quarterMaster.aspx?mode=edit"));tmp.mnemonic = '';m_07.add(tmp = new MenuItem("View","/wap/ppms/quarterMaster.aspx?mode=view"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Setup", m_00) );
tmp.mnemonic = '';

menuBar.write();
