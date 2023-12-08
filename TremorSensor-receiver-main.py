# Imports go at the top
from microbit import *
import radio

radio.on()
# Code in a 'while True:' loop repeats forever
while True:
    received = radio.receive()
    if received != None:
        print(received)
    
