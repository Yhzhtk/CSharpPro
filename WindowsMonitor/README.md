WindowsMonitor
=========

注：要使用本软件监控远程电脑需要以下条件

- 控制端和被控端需要在同一局域网内
- 两端可互相访问（防火墙通过）
- 被控端启动运行着PCMonitor，任务管理器关闭之后就不可用了
- 控制端需要知道PCMonitor的IP地址

故该监控项目是合理正常的代码，不是病毒也不是蠕虫，需要双方同意的。适合 **管理员** 远程控制自己或者自己有权限访问的电脑。

## PCMonitor

电脑监控软件—被控端。

运行在需要控制的电脑上。接受PCControl发送信号并处理，为PCMonitor提供获取文件、查看桌面等功能，无界面后台运行。

被控端下载: 
[链接一](https://github.com/Yhzhtk/WindowsMonitor/blob/master/PCMonitor/PCMonitor/bin/Debug/PCMonitor.exe?raw=true) | 
[链接二](https://raw.githubusercontent.com/Yhzhtk/WindowsMonitor/master/PCMonitor/PCMonitor/bin/Debug/PCMonitor.exe)


## PCContorl

电脑监控软件—控制端。

- 运行在可访问PCMonitor的同一网络的任一台电脑。可使用界面完成获取文件、查看桌面、发送消息等远程桌面的功能。

控制端下载: 
[链接一](https://github.com/Yhzhtk/WindowsMonitor/blob/master/PCContorl/PCContorl/bin/Debug/PCContorl.exe?raw=true) | 
[链接二](https://raw.githubusercontent.com/Yhzhtk/WindowsMonitor/master/PCContorl/PCContorl/bin/Debug/PCContorl.exe)
