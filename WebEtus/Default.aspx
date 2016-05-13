<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Kullanıcı Girişi</title>
    
    <script>
        // Invalidate the login fields with the given reason.
        var invalidateLogin = function (reason) {
            App.txtUsername.setValidation(reason);
            App.txtPassword.setValidation(reason);
            App.txtUsername.validate();
            App.txtPassword.validate();

            Ext.MessageBox.show({
                title: 'Authentication error',
                msg: reason,
                buttons: Ext.MessageBox.OK,
                animateTarget: 'Window1',
                icon: 'Error'
            });
        };

        var handleLogin = function () {
            var form = App.Window1.el.up().dom; // Window1 is a direct child of the form element.

            App.Window1.close();

            // Now this would work for Chrome, and we already triggered autoComplete for IE.
            // Chrome's is only triggered after the destination page is loaded.
            setForm(form, "../../../Desktop/Introduction/Overview/Desktop.aspx", form.target);
            form.submit();
            restoreForm(form);
        };

        var orgFormAction, orgFormTarget,
            btn = null, iframe = null;

        // If we are on IE, we will create a button and click it (at once),
        // so autoComplete is triggered.
        var handleClientClick = function () {
            var form = App.Window1.el.up().dom; // Window1 is a direct child of the form element.

            if (Ext.isIE) {
                if (iframe == null) {
                    iframe = document.createElement("IFRAME");
                    iframe.name = "ie_login_flush";
                    iframe.style.display = "none";
                    form.appendChild(iframe);
                }

                if (btn == null) {
                    btn = document.createElement("BUTTON");
                    btn.type = "submit";
                    btn.id = "submitButton";
                    btn.style.display = "none";
                    form.appendChild(btn);
                }

                // On WebForms, we have to force set the form settings as we run or else we'll
                // break directEvent calls.
                setForm(form, "about:blank", "ie_login_flush");
                btn.click();
                restoreForm(form);
            }
        }

        var setForm = function (form, action, target) {
            // Back up original settings once per execution.
            if (typeof orgFormAction == 'undefined') {
                orgFormAction = form.action;
            }
            if (typeof orgFormTarget == 'undefined') {
                orgFormTarget = form.target;
            }

            form.action = action;
            form.target = target;
        };

        var restoreForm = function (form) {
            form.action = orgFormAction;
            form.target = orgFormTarget;
        };
    </script>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server"></ext:ResourceManager>
    <form id="form1" runat="server">
    <ext:Window ID="Window1" runat="server" Title="Kullanıcı Girişi" Modal="true" Width="350" Height="200" Padding="10" BodyStyle="background-color:white;">
        <Items>
            <ext:TextField runat="server" ID="txtUsername" FieldLabel="Kullanıcı Adı" Padding="10"></ext:TextField>
            <ext:TextField runat="server" ID="txtPassword" FieldLabel="Şifre" InputType="Password" Padding="10"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" Text="Kullanıcı Girişi" Icon="Lock" ID="btnLogin" OnDirectClick="btnLogin_DirectClick">
                <DirectEvents>
                    <Click>
                        <EventMask ShowMask="true" Msg="Lütfen bekleyiniz"></EventMask>
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>