#import <Foundation/Foundation.h>
#import "DataConvertor.h"
extern "C" typedef void (*OkCallback)();
extern "C" typedef void (*YesCallback)();
extern "C" typedef void (*NoCallback)();
extern "C" {
    // Unity Call
    void ShowMessage(char* title, char* msg, char* ok, OkCallback cb) {
        UIAlertController *alertController = [UIAlertController alertControllerWithTitle:[DataConvertor charToNSString:title] message:[DataConvertor charToNSString:msg] preferredStyle:UIAlertControllerStyleAlert];
        UIAlertAction *okAction = [UIAlertAction actionWithTitle:[DataConvertor charToNSString:ok] style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
            (cb)();
        }];
        [alertController addAction:okAction];
        [[[[UIApplication sharedApplication] keyWindow] rootViewController] presentViewController:alertController animated:YES completion:nil];
    }

    void ShowDialog(char* title, char* msg, char* yes, char* no, YesCallback ycb, NoCallback ncb) {
        UIAlertController *alertController = [UIAlertController alertControllerWithTitle:[DataConvertor charToNSString:title] message:[DataConvertor charToNSString:msg] preferredStyle:UIAlertControllerStyleAlert];
        UIAlertAction *yesAction = [UIAlertAction actionWithTitle:[DataConvertor charToNSString:yes] style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
            (ycb)();
        }];
        UIAlertAction *noAction = [UIAlertAction actionWithTitle:[DataConvertor charToNSString:no] style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
            (ncb)();
        }];
        [alertController addAction:yesAction];
        [alertController addAction:noAction];
        [[[[UIApplication sharedApplication] keyWindow] rootViewController] presentViewController:alertController animated:YES completion:nil];
    }
}

