#import led_colourchange
import time
import digitalio
import board
import adafruit_hcsr04
import pwmio

sonar = adafruit_hcsr04.HCSR04(trigger_pin=board.GP15, echo_pin=board.GP14)

def getdistanz():
    try:
        return sonar.distance
    except RuntimeError:
        return -1