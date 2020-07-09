Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mA03= new Menu();
var tmp;

var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Misc. E/Ds", mA03) );
tmp.mnemonic = '';

menuBar.write();
