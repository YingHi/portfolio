import './App.css';
import React, { useEffect, useState } from "react";
import io from "socket.io-client";

const socket = io.connect("http://localhost:3000");

function App() {
  const [chat, setChat] = useState([]); // 채팅기록
  const [info, setInfo] = useState({
    id : "Visiter", 
    message : "",
  }); // 내 정보 

  const sendMessageHandler = () => { // 채팅을 보내는 메소드
    socket.emit("message", info);
    setInfo({...info, message : ""})
  };

  useEffect(() => {
    socket.on("message", (message) => {
      setChat([...chat, {id : message.id, message : message.message}]);
    });
  }, [chat]);

  return (
    <div className="App">
      <div>
        <h1>My name</h1>
        <input value={info.id} onChange={(e) => setInfo({...info, id : e.target.value})} />
        <h1>Messages</h1>
      </div>
      <div id = "messages">
        <ul id = "list">
          {chat.map((data, idx) => {
            return <li key={idx}>{data.id} : {data.message}</li>;
          })}
        </ul>
      </div>
      <div>
        <h1>Chat Box</h1>
        <input value={info.message} onChange={(e) => setInfo({...info, message : e.target.value})} />
        <button onClick={sendMessageHandler}>Send Message</button>
      </div>
    </div>
  );
}

export default App;
