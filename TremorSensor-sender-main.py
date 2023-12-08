# Imports go at the top
from microbit import *
import radio

radio.on()
# Code in a 'while True:' loop repeats forever
while True:
    x,y,z = accelerometer.get_values()
    values = str(x)+ " " + str(y) + " " + str(z)
    radio.send(values)
    print("sent on radio")
    sleep(50)
