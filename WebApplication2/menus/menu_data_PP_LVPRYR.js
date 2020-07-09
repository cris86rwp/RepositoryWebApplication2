Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mL02= new Menu();var mLR03= new Menu();
var tmp;
mL02.add(tmp = new MenuItem("Leave Accounting Prev Year",null,null, mLR03) );
tmp.mnemonic = ' ';
mLR03.add(tmp = new MenuItem("Add","/ppms/leave/leaveApplication_prev_year.aspx?mode=add"));tmp.mnemonic = ' ';mLR03.add(tmp = new MenuItem("Cancel","/ppms/leave/editApplicationForLeave_prev_year.aspx?mode=cancel"));tmp.mnemonic = ' ';mLR03.add(tmp = new MenuItem("Delete","/ppms/leave/editApplicationForLeave_prev_year.aspx?mode=delete"));tmp.mnemonic = ' ';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Leave Accounting", mL02) );
tmp.mnemonic = '';

menuBar.write();
