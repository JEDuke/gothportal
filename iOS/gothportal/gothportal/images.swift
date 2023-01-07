//
//  images.swift
//  gothportal
//
//  Created by Ethan Duke on 12/22/22.
//

import Foundation
import UIKit

class Api : ObservableObject{
    @Published var gothImage = UIImage()
    
    func loadData(completion:@escaping (UIImage) -> ()) {
        
        let i = arc4random_uniform(5) + 1 // 1...5
        
        guard let url = URL(string: "https://gothapi.azurewebsites.net/api/imageuploader?name=homepage" + String(i) + ".jpeg") else {
            print("Invalid url...")
            return
        }
        
        URLSession.shared.dataTask(with: url) { data, response, error in
            let decodedData = Data(base64Encoded: data!, options: .ignoreUnknownCharacters)
            let gothImage = UIImage(data: decodedData!)
            DispatchQueue.main.async {
                completion(gothImage!)
            }
        }.resume()
    }
}
