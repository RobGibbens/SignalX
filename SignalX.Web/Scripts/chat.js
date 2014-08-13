var $j = $.noConflict();

$j(function () {
    var chatConn = $j.connection.chathub;
    var conflictConn = $j.connection.conflicthub;

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
    });

    $j('#clear').on('click', function (e) {
        e.preventDefault();
        $j('#messages').empty();
    });

});