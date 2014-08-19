var $j = $.noConflict();

$j(function () {
    var chatConn = $j.connection.chathub;
    var conflictConn = $j.connection.conflicthub;
    var newsConn = $j.connection.newshub;
    var alertConn = $j.connection.alerthub;
    var userId = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
    chatConn.client.addMessage = function (message, id) {
        $j('#messages').append('<li class="list-group-item">' + message + ' ' + id + '</li>');
    };

    $j.connection.hub.start().done(function () {
        $j('#send').click(function (e) {
            e.preventDefault();
            var messageToSend = $j('#message').val();
            console.log("message:" + messageToSend);
            console.log("userId:" + userId);
            chatConn.server.sendMessage(messageToSend, userId);
            $j('#message').val('');
            $j('#message').focus();
        });

        $j('#saveUser').click(function (e) {
            conflictConn.server.saveUser();
        });

        $j('#sendAlert').click(function () {
            var message = $j('#alertMessage').val();
            alertConn.server.sendAlert(message);
        });

        $j('#addNews').click(function (e) {
            var title = $j('#newsTitle').val();
            var body = $j('#newsBody').val();

            newsConn.server.addNews(title, body);
        });
    });

    $j('#clear').on('click', function (e) {
        e.preventDefault();
        $j('#messages').empty();
    });

});