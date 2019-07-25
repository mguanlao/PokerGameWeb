<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PokerGame.aspx.cs" Inherits="PokerGameWeb.PokerGame" %>
<%@ Register TagPrefix="UserControl" 
             TagName="PlayerHand" 
             Src="~/PlayerHand.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Poker Game</title>
    <link rel="stylesheet" href="/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="/css/PlayerHand.css"/>
</head>
<body>
    <form runat="server">
        <div class="jumbotron">
            <h1 class="display-3">Poker Game</h1>
            <hr class="my-4"/>

            <div class="container">
                <div class="row">
                    <div class="col-9">
                        <div id="divPlayers">
                            <div class="container">
                                <div class="row">
                                    <div class="col-3">
                                        <asp:Button class="btn btn-primary" runat="server" Text="Start Game" OnClick="GameStart_OnClick" ID="btnStartGame"></asp:Button>
                                        <asp:Button class="btn btn-primary" runat="server" Text="Evaluate Hands" OnClick="EvaluateHands_OnClick" 
                                            ID="btnEvaluateHands" Visible="false"></asp:Button>
                                        <asp:Button class="btn btn-primary" runat="server" Text="New Game" OnClick="NewGame_OnClick" 
                                            ID="btnNewGame" Visible="false"></asp:Button>
                                        <hr class="my-4"/>
                                    </div>

                                    <div class="col-9">
                                        <asp:label ID="lblDisplayError" runat="server" CssClass="alert-warning"></asp:label>
                                        <asp:label ID="lblDisplayWinner" runat="server" CssClass="alert-success"></asp:label>
                                    </div>
                                    
                                </div>
                    
                                <div class="row">
                                    <div class="col-3">
                                        <asp:TextBox runat="server" ID="txtComputer1" Text="Player 1"></asp:TextBox>  
                                    </div>

                                    <div class="col-9">
                                        <asp:label ID="lblCompHand" runat="server" class="alert-success"></asp:label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-12">
                                        <UserControl:PlayerHand runat="server" ID="ucComputerHand"></UserControl:PlayerHand>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-3">
                                        <asp:TextBox runat="server" ID="txtPlayer" Text="Player 2"></asp:TextBox>
                                    </div>
                                    <div class="col-9">
                                        <asp:label ID="lblPlayerHand" runat="server" class="alert-success"></asp:label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <UserControl:PlayerHand runat="server" ID="ucPlayerHand"></UserControl:PlayerHand>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="col-3">
                        <div id="divSessionStats">
                            <div class="container">
                                <div class="row">
                                    <div class="col-12">
                                        <p class="lead">Session Stats</p>
                                        <hr class="my-4"/>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-12">
                                        <asp:GridView ID="gvSessionStats" runat="server" EmptyDataText="No games played yet."
                                            AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Game Number">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGameNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "gameNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Game Winner">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGameWinner" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "gameWinner") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Winning Hand">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWinningHand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "winningHand") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>    
                </div>
            </div>
        </div>
    </form>
    <script src="/js/bootstrap.min.js"></script>
</body>
</html>
