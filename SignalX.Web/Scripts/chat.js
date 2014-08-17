var $j = $.noConflict();

$j(function () {
    var chatConn = $j.connection.chathub;
    var conflictConn = $j.connection.conflicthub;
    var newsConn = $j.connection.newshub;
    var alertConn = $j.connection.alerthub;

    chatConn.client.addMessage = function (message) {
        $j('#messages').append('<li class="list-group-item">' + message + '</li>');
    };

    $j.connection.hub.start().done(function () {
        $j('#send').click(function (e) {
            e.preventDefault();
            var messageToSend = $j('#message').val();
            chatConn.server.sendMessage(messageToSend);
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