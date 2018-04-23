;#DropDB ExtendModelEasyTest

#Application ExtendModelWin
#Application ExtendModelWeb

*Action Navigation(User)

*ProcessRecord
 Full Name = ''

#IfDef ExtendModelWeb
*Action Edit
#EndIf
 
*FillForm
 Full Name = Test User
 
*Action Cancel

#IfDef ExtendModelWin
*HandleDialog
 Respond = Yes
#EndIf

*CheckFieldValues
 Full Name = ''
