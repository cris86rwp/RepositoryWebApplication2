Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mD50= new Menu();var mD70= new Menu();var mD61= new Menu();
var tmp;
mD50.add(tmp = new MenuItem("General Data","/ppms/sr/hr_sr_generalData.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Promotions","/ppms/sr/hr_sr_promotions.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Increments","/ppms/sr/hr_sr_increments.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Stepping Up Of Pay","/ppms/sr/hr_sr_steppingupofpay.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Awards","/ppms/sr/hr_sr_awards.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Advances","/ppms/sr/hr_sr_advances.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Deputations","/ppms/sr/hr_sr_deputations.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Training Details","/ppms/sr/hr_sr_trainingdetails.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Non Qualifying Service","/ppms/sr/hr_sr_nonqualifyingservice.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Medical Certification","/ppms/sr/hr_sr_medicalcertification.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Penalties","/ppms/sr/hr_sr_penalties.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Educational Qualification","/ppms/sr/hr_sr_qualification.aspx"));tmp.mnemonic = '';mD50.add(tmp = new MenuItem("Parent Railway","/ppms/sr/hr_sr_parentRailway.aspx"));tmp.mnemonic = '';mD61.add(tmp = new MenuItem("SR Report","/ppms/sr/rptsServiceRegister.aspx"));tmp.mnemonic = '';mD61.add(tmp = new MenuItem("SAKSHAM","/ppms/sr/rptsSaksham.aspx"));tmp.mnemonic = '';mD70.add(tmp = new MenuItem("Statistics","/ppms/sr/hr_sr_stats.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Service Register - Entry", mD50) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Queries", mD70) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Report", mD61) );
tmp.mnemonic = '';

menuBar.write();
