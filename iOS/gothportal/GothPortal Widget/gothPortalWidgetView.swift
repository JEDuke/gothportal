//
//  gothPortalWidgetView.swift
//  GothPortal WidgetExtension
//
//  Created by Ethan Duke on 12/22/22.
//

import Foundation
import SwiftUI

struct gothPortalWidgetView: View {
    
    @State var gothImage = UIImage()
    
    var body: some View {
        Image(uiImage: gothImage)
            .resizable()
            .aspectRatio(contentMode: .fill)
            .frame(minWidth: 0, maxWidth: .infinity)
            .edgesIgnoringSafeArea(.all)
            .onAppear() {
                Api().loadData { (gothImage) in
                    self.gothImage = gothImage
                }
            }.navigationTitle("gothportal")
            .padding(.horizontal, 24)
    }
}
