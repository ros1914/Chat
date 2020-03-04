var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

connection.on("NewMessage", function (message) {
	console.log(`[${message.user}] ${message.text}`);
	//message.user
	//message.text
	// TODO: Visualize the message
})

$("#sendButton").click(function () {
	var user = $("#inputUser").val();
	var message = $("#messageInput").val();
	connection.invoke("Send", user, message);
})

connection.start().catch(function (err) {
	return console.error(err.toString());
});