#!/usr/bin/env sh
cat words.txt | tr -s ' ' '\n' | sort | uniq -c | sort -rn -k 1 | awk '{print $2, $1}'