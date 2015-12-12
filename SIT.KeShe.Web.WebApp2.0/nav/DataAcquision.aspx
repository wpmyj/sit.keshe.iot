<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataAcquision.aspx.cs" Inherits="SIT.KeShe.Web.WebApp2._0.nav.DataAcquision" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="../Style/bootstrap.min.css" rel="stylesheet" />
    <link href="../Style/StyleSheet.css" rel="stylesheet" />
    <title>传感器类型信息</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <nav class="navbar navbar-inverse navbar-fixed-top">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="../Index.aspx">分布式数据采集/控制系统</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                            导航<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="SensorTypeInfo.aspx">传感器类型信息</a></li>
                                <li><a href="DataAcquision.aspx">实时数据监控</a></li>
                            </ul>
                        </li>
                        <li><a href="../About.aspx">About</a></li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-3 col-md-2 sidebar">
                    <ul class="nav nav-sidebar">
                        <li><a href="SensorTypeInfo.aspx">传感器类型信息</a></li>
                        <li><a href="DataAcquision.aspx">实时数据监控</a></li>
                    </ul>
                </div>
                <div class='col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main'>
                    <h1 class='page-header'>实时数据监控</h1>
                    <div class='row placeholders'>
                        <div class='col-xs-6 col-sm-3 placeholder'>
                            <select class='form-control' id='selectNode'>
                                <option value="0">请选择节点</option>
                                <%  foreach(var node in lsNode)
                                    {%>
                                <option value="<%=node %>"><%=node %></option>
                                <%  }%>
                            </select>
                        </div>
                        <div class='col-xs-6 col-sm-3 placeholder'>
                            <select class='form-control' id='selectSensor'>
                                <option value="0">请选择传感器</option>
                                <%  for(int i=0;i<lsSensor.Count;i++)
                                    {%>
                                <option value="<%=lsSensor[i] %>"><%=lsSensorType[i] %></option>
                                <%  }%>
                            </select>
                        </div>
                    </div>
                    <div class='table-responsive'>
                            <table class='table table-striped'>
                                <thead id="tbHead">

                                </thead>
                                <tbody id="tbBody">

                                </tbody>
                            </table>
                        </div>
                </div>
            
            </div>
        </div> 
        <script src="../JS/jquery-2.1.4.min.js"></script>
        <script src="../JS/bootstrap.min.js"></script>
        <script src="../JS/datapattern.js"></script>
        <script type="text/javascript">
            $(function () {
                setInterval("NodeSensor()", 1000);
            });
            function NodeSensor() {
                var node = $("#selectNode").val();
                var sensor = $("#selectSensor").val();
                //var ur="node="+node+"&sensor="+sensor;
                $.getJSON("DAjson.ashx", {node:node,sensor:sensor}, function(lsd) {
                    if (sensor=="1") {
                        $("#tbHead").html("");
                        $("#tbBody").html("");
                        var str;
                        str = "<tr><th>#</th><th>节点</th><th>传感器</th><th>温度</th><th>湿度</th><th>时间</th></tr>";
                        $("#tbHead").append(str);
                        str = "";
                        var j = 0;
                        for (var i in lsd) {
                            var date = (eval(lsd[i].DTTime.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-MM-dd hh:mm:ss");
                            str += "<tr><td>" + (j++) + "</td><td>" + lsd[i].Node + "</td><td>" + "温湿度传感器" + "</td><td>" + lsd[i].V1 + "</td><td>" + lsd[i].V2 + "</td><td>" + date + "</td></tr>"
                        }
                        $("#tbBody").append(str);
                    }
                    if (sensor == "3") {
                        $("#tbHead").html("");
                        $("#tbBody").html("");
                        var str="";
                        str += "<tr><th>#</th><th>节点</th><th>传感器</th><th>光强</th><th>时间</th></tr>";
                        $("#tbHead").append(str);
                        str = "";
                        var j = 0;
                        for (var i in lsd) {
                            var date = (eval(lsd[i].DTTime.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-MM-dd hh:mm:ss");
                            str += "<tr><td>" + (j++) + "</td><td>" + lsd[i].Node + "</td><td>" + "光传感器" + "</td><td>" + lsd[i].V1 + "</td><td>" + date + "</td></tr>"
                        }
                        $("#tbBody").append(str);
                    }
                });
            }
        </script>   
    </div>
    </form>
</body>
</html>