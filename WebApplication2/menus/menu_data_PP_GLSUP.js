Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mU00= new Menu();
var tmp;
mU00.add(tmp = new MenuItem("E Suspense Process","/ppms/eSuspense/eSuspense.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("E Suspense", mU00) );
tmp.mnemonic = '';

menuBar.write();
