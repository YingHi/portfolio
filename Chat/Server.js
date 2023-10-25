const express = require('express'); //웹프레임워크 express 리콰이어
const http = require("http");
const path = require('path');
const app = express(); // app에 express 할당
const server = http.createServer(app);
const port = 3000; // 포트번호 지정
const SocketIO = require('socket.io');
const io = SocketIO(server);

app.use(express.static(path.join(__dirname, '../front_end/build')));

io.on('connection', function (socket) {
    io.emit('message', {
        id : "server",
        message : "채팅방에 새로운 유저가 접속했습니다.",
    });
  
    socket.on('message', function (data) {
        io.emit('message', data);
    });

    socket.on('disconnect', function () {
        io.emit('message', {
            id : "server",
            message : "채팅방에서 유저 한명이 퇴장했습니다.",
        });
    });
});

app.get('/', function(req, res) {
    res.sendFile(path.join(__dirname, '../front_end/build/index.html'));
});

server.listen(port);
