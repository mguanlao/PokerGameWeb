<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlayerHand.ascx.cs" Inherits="PokerGameWeb.PlayerHand" %>

<div class="body container">
    <div class="row">
        <div class="col-2 offset-1">
            <div class="outline shadow rounded" id="divCard1" runat="server">
                <div class="top"><asp:label id="topNumber1" runat="server"></asp:label><asp:label id="topSuit1" runat="server"></asp:label></div>
                <h1><asp:label id="midSuit1" runat="server"></asp:label></h1>
                <div class="bottom"><asp:label id="botSuit1" runat="server"></asp:label><asp:label id="botNumber1" runat="server"></asp:label></div>
            </div>    
        </div>

        <div class="col-2">
            <div class="outline shadow rounded" id="divCard2" runat="server" >
                <div class="top"><asp:label id="topNumber2" runat="server"></asp:label><asp:label id="topSuit2" runat="server"></asp:label></div>
                <h1><asp:label id="midSuit2" runat="server"></asp:label></h1>
                <div class="bottom"><asp:label id="botSuit2" runat="server"></asp:label><asp:label id="botNumber2" runat="server"></asp:label></div>
            </div>    
        </div>

        <div class="col-2">
            <div class="outline shadow rounded" id="divCard3" runat="server">
                <div class="top"><asp:label id="topNumber3" runat="server"></asp:label><asp:label id="topSuit3" runat="server"></asp:label></div>
                <h1><asp:label id="midSuit3" runat="server"></asp:label></h1>
                <div class="bottom"><asp:label id="botSuit3" runat="server"></asp:label><asp:label id="botNumber3" runat="server"></asp:label></div>
            </div>    
        </div>

        <div class="col-2">
            <div class="outline shadow rounded" id="divCard4" runat="server">
                <div class="top"><asp:label id="topNumber4" runat="server"></asp:label><asp:label id="topSuit4" runat="server"></asp:label></div>
                <h1><asp:label id="midSuit4" runat="server"></asp:label></h1>
                <div class="bottom"><asp:label id="botSuit4" runat="server"></asp:label><asp:label id="botNumber4" runat="server"></asp:label></div>
            </div>        
        </div>

        <div class="col-2">
            <div class="outline shadow rounded" style="float:left" id="divCard5" runat="server">
                <div class="top"><asp:label id="topNumber5" runat="server"></asp:label><asp:label id="topSuit5" runat="server"></asp:label></div>
                <h1><asp:label id="midSuit5" runat="server"></asp:label></h1>
                <div class="bottom"><asp:label id="botSuit5" runat="server"></asp:label><asp:label id="botNumber5" runat="server"></asp:label></div>
            </div>
        </div>
    </div>

    <div class="row" style="padding-left: 13px;">
        <div class="col-2 offset-1">
            <asp:Button class="btn btn-primary" runat="server" Text="Redraw Card" OnClick="btnRedraw_Click" ID="btnRedraw1" Visible="false"></asp:Button>
        </div>

        <div class="col-2">
            <asp:Button class="btn btn-primary" runat="server" Text="Redraw Card" OnClick="btnRedraw_Click" ID="btnRedraw2" Visible="false"></asp:Button>
        </div>

        <div class="col-2">
            <asp:Button class="btn btn-primary" runat="server" Text="Redraw Card" OnClick="btnRedraw_Click" ID="btnRedraw3" Visible="false"></asp:Button>
        </div>

        <div class="col-2">
            <asp:Button class="btn btn-primary" runat="server" Text="Redraw Card" OnClick="btnRedraw_Click" ID="btnRedraw4" Visible="false"></asp:Button>
        </div>

        <div class="col-2">
            <asp:Button class="btn btn-primary" runat="server" Text="Redraw Card" OnClick="btnRedraw_Click" ID="btnRedraw5" Visible="false"></asp:Button>
        </div>
    </div>
    
</div>



