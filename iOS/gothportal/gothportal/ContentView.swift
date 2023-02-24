//
//  ContentView.swift
//  gothportal
//
//  Created by Ethan Duke on 12/22/22.
//

import SwiftUI

struct ContentView: View {
    
    @State var gothImage = UIImage()
    
    var body: some View {
        
        Image(uiImage: gothImage)
            .resizable()
            .aspectRatio(contentMode: .fill)
            .frame(minWidth: 0, maxWidth: .infinity)
            .edgesIgnoringSafeArea(.all)
            .onAppear() {
                Api().loadData { (g) in
                    self.gothImage = g
                }
            }.navigationTitle("gothportal")
            .padding(.horizontal, 24)
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
