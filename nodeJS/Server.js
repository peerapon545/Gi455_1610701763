var websocket = require('ws');
var callbackServer = ()=>{
    console.log("is running.");
}
var wss = new websocket.Server({port:51000},callbackServer);

var wsList = [];
wss.on("connection",(ws) =>
{
   console.log("client connected")
   wsList.push(ws);
   ws.on("message",(data)=>{
       console.log("send : "+ data);
       boradcast(data);
   });

   ws.on("close",()=>{
       console.log("disconnected");
       wsList = ArrayRemove(wsList,ws);

   });
});
function ArrayRemove(arr,value)
{
    return arr.filter((element)=>{
        return element !=value;
    });
}

function boradcast(data)
{
    for(var i = 0; i < wsList.length; i++)
    {
        wsList[i].send(data);
    }
}