# PingDog
Runs Serial Port RTS line as toggle to control SSR power to IP appliance

This app resolves an issue arising from a server that locked due to a memory fault. I needed a way to reset the server remotely.

Combined with a magic box that has an RS232 port, an interface circuit and a solid state relay, the app resets the ac power to the server by running on an adjacent pc.

The app periodically pings the server and waits for a response.  If the server does not respond, the app briefly interrupts the power, waits until the server restarts and repeats the cycle.
