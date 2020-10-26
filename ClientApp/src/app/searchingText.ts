import { Injectable } from "@angular/core";

@Injectable()
export class SearchingText {

    hasAllCharsOf(text: string, charsToSearch: string) : boolean {
        // removing spaces from string
        charsToSearch   = charsToSearch.replace(/\s/g, "");

        charsToSearch   = charsToSearch.toLowerCase();
        text            = text.toLowerCase();

        var hasAllChars = false;
        var index       = 0;

        for (var searchChar of charsToSearch) {
            hasAllChars = false;
            for (let i = index; i < text.length; i++) {
                if (searchChar !== text[i]) continue;

                index       = i + 1;
                hasAllChars = true;
                break;
            }
            if (!hasAllChars) break;
        }
        return hasAllChars;
    }
}