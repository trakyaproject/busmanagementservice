<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server"></ext:ResourceManager>
    <form id="form1" runat="server">
    
        <ext:Window runat="server" Modal="true" Title="Kullanıcı Girişi" Closable="false" Draggable="false" Width="400" Height="150" ButtonAlign="Center">
            <Items>
                <ext:TextField ID="txtUserName" runat="server" FieldLabel="E-posta Adresi" InputType="Email" Padding="10"></ext:TextField>
                <ext:TextField ID="txtPassword" runat="server" FieldLabel="Şifre" InputType="Password" Padding="10"></ext:TextField>
            </Items>
            <Buttons>
                <ext:Button ID="btnLogin" runat="server" Text="Giriş Yap" Icon="LockGo" >
                    <DirectEvents>
                        <Click>
                            <EventMask ShowMask="true" Msg="Lütfen bekleyiniz.."></EventMask>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnForgetPassword" runat="server" Text="Şifremi Unuttum" Icon="Information" ></ext:Button>
            </Buttons>
        </ext:Window>

    </form>
</body>
</html>
