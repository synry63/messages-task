import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'

export function hubMessageChange(callback) {
    var connection = new HubConnectionBuilder()
        .withUrl('http://localhost:8769/message-hub')
        .configureLogging(LogLevel.Information)
        .build();

    connection.start();

    connection.on('MessageChange', (total, userId) => {
        callback(total, userId);
    })
}