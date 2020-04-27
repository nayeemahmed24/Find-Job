
        "use strict";

        var connection = new signalR.HubConnectionBuilder().withUrl("/Chatter/Index").build();

//        //Disable send button until connection is established
        document.getElementById("sendButton").disabled = true;

        connection.on("ReceiveMessage", function (user, message) {
            var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
            var encodedMsg =  msg;
            var li = document.createElement("li");
//            li.textContent = encodedMsg;
//            need work
//            document.getElementById("messagesList").appendChild(li);

            //
            
            var chat = document.createElement("div");
            if (user !== myself) { // Myself need to define
                chat.setAttribute("class", "chat grid-item chat-my");
            } else {
                chat.setAttribute("class", "chat grid-item chat-other");
            }
            var container = document.createElement("div");
            container.setAttribute("class", "container-chat");
            var par = document.createElement("p");
            par.textContent = encodedMsg;
            par.style.marginTop = "25px"; // need to done
            container.appendChild(par);
            chat.appendChild(container);
            document.getElementById("messagesList").appendChild(chat);

        });

        connection.start().then(function () {
        document.getElementById("sendButton").disabled = false;
    }).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
//    console.log("HI");
    var request = new XMLHttpRequest();
    event.preventDefault();
    var message = document.getElementById("messageInput").value;
    console.log(reciver+extension)

    request.open("GET", "/chatter/create?chat=" + message + "&reciever=" + reciver + "&ext=" + extension, true);

    
    
    
    request.onload = function () {
        if (this.status === 200) {
            
            connection.invoke("SendMessage", reciver+"@"+extension, message , myself).catch(function (err) {
                return console.error(err.toString());
            });
        }
        
    };
    
    request.send();
  
        
    
});
    
