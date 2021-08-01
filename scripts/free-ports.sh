#!/bin/zsh

kill $(lsof -ti:5000,5001)
