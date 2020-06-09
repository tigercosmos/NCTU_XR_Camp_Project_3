import os
import re

# os.system("./mid2asc music3.mid > text.tmp")

filepath = 'text.tmp'
with open(filepath) as fp:
    lines = fp.readlines()

    duration = lines[-1]
    duration = re.search(r"\d+.\d+", duration)
    duration = float(duration.group(0))
    print("duration: ", duration)

    new_lines = []

    for line in lines:
        tokens = line.split(" ")
        tokens = [token for token in tokens if token != '']
        new_lines.append(tokens)

    total_period = 0

    idx = -1
    while(True):
        tokens = new_lines[idx]
        if len(tokens) > 8 and tokens[-3] == "End":
            total_period = int(tokens[1]) + float(eval(tokens[3]))/4
            print("total period: ", total_period)
            break
        idx -= 1

    per_period_time = duration/total_period

    print("per period time: ", per_period_time)

    beats = []
    last_time = 0
    for tokens in new_lines:
        if len(tokens) == 12:
            von = tokens[-1].split('\n')[0]
            von = von.split("=")[1]
            von = int(von)

            period = int(tokens[1])-1 + float(eval(tokens[3]))/4
            print("period von ", period, von)
            time = per_period_time * period

            key = tokens[9][0]

            # if key in ["E", "G", "A", "C"]:
            if True:
                if von > 50:
                    last_time = time
                    beats.append(time)

                if time - last_time > 1.5:
                    if von > 30:
                        last_time = time
                        beats.append(time)
                    elif time - last_time > 2:
                        if von > 15:
                            last_time = time
                            beats.append(time)
                    elif time - last_time > 2.5:
                        last_time = time
                        beats.append(time)

    print("Beats: ", len(beats))

    data = ""
    for beat in beats:
        data += str(beat) + '\n'

    f = open("beat.txt", "w")
    f.write(data)
